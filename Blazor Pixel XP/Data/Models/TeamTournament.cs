// Data/Models/TeamTournament.cs
using System;

namespace Blazor_Pixel_XP.Data.Models
{
    public class TeamTournament
    {
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}
