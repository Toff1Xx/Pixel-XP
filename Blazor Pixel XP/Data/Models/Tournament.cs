// Data/Models/Tournament.cs
using System;
using System.Collections.Generic;

namespace Blazor_Pixel_XP.Data.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<TeamTournament> TeamRegistrations { get; set; } = new List<TeamTournament>();
        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
