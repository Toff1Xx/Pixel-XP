// Data/Models/Match.cs
using System;

namespace Blazor_Pixel_XP.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;

        public int TeamAId { get; set; }
        public Team TeamA { get; set; } = null!;

        public int TeamBId { get; set; }
        public Team TeamB { get; set; } = null!;

        public int ScoreA { get; set; }
        public int ScoreB { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
