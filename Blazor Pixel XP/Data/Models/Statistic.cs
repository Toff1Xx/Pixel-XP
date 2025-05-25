// Data/Models/Statistic.cs
namespace Blazor_Pixel_XP.Data.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; } = null!;

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public int Points { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
    }
}
