// Data/Models/Team.cs
using System.Collections.Generic;
using Blazor_Pixel_XP.Data.Models;

namespace Blazor_Pixel_XP.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? CaptainId { get; set; }
        public ApplicationUser? Captain { get; set; }

        public ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
        public ICollection<TeamTournament> Registrations { get; set; } = new List<TeamTournament>();
    }
}
