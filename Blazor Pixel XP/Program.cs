using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Blazor_Pixel_XP.Components;
using Blazor_Pixel_XP.Components.Account;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;       // для IdentityRole
using Microsoft.AspNetCore.Identity.UI;    // для AddDefaultIdentity
using Blazor_Pixel_XP.Data;

var builder = WebApplication.CreateBuilder(args);

// a) DbContext + Identity
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
  opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddDefaultIdentity<ApplicationUser>(opts => {
    opts.Password.RequiredLength = 6;
    opts.Password.RequireDigit = true;
})
  .AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>();

// b) Авторизація
builder.Services.AddAuthorization(opts => {
    opts.AddPolicy("RequireAdmin", p => p.RequireRole("Admin"));
});

// c) Blazor Server та Razor Pages
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DataSeeder.SeedAsync(services);
}
app.Run();