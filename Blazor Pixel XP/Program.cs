// Program.cs
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Blazor_Pixel_XP.Data;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// 1) ������������ DbContext �� retry-��������������
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
    opts.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOpts => sqlOpts.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        )
    )
);

// 2) ����� ������ (Identity, RazorPages, ServerSideBlazor, MudBlazor)
builder.Services.AddDefaultIdentity<ApplicationUser>(opts => {
    opts.Password.RequiredLength = 6;
    opts.Password.RequireDigit = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(opts =>
    opts.AddPolicy("RequireAdmin", p => p.RequireRole("Admin"))
);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// 3) ����������� ����������� �� ������� ����� SeedAsync
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var db = services.GetRequiredService<ApplicationDbContext>();
    // ����������� ������� (������� �������, ���� �� ����)
    await db.Database.MigrateAsync();

    // ����� ����� ��� ��� �� �����
    await DataSeeder.SeedAsync(services);
}

// 4) Endpoint-� ��� Blazor Server
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
