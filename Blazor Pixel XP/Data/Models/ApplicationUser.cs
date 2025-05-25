// Data/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace Blazor_Pixel_XP.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Додаткові поля (за потреби)
        public string? FullName { get; set; }
    }
}
