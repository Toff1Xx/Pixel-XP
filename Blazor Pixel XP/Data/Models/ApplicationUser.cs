// Data/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace Blazor_Pixel_XP.Data
{
    public class ApplicationUser : IdentityUser
    {
        // �������� ���� (�� �������)
        public string? FullName { get; set; }
    }
}
