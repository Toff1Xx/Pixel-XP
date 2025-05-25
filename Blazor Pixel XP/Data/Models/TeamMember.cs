// Data/Models/TeamMember.cs
using System;

namespace Blazor_Pixel_XP.Data.Models
{
    public class TeamMember
    {
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
