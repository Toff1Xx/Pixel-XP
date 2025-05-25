// Data/ApplicationDbContext.cs
using Blazor_Pixel_XP.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Pixel_XP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamTournament> TeamTournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.UserId });
            builder.Entity<TeamTournament>()
                .HasKey(tt => new { tt.TeamId, tt.TournamentId });

            builder.Entity<TeamMember>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(tm => tm.TeamId);
            builder.Entity<TeamMember>()
                .HasOne(tm => tm.User)
                .WithMany()
                .HasForeignKey(tm => tm.UserId);

            builder.Entity<TeamTournament>()
                .HasOne(tt => tt.Team)
                .WithMany(t => t.Registrations)
                .HasForeignKey(tt => tt.TeamId);
            builder.Entity<TeamTournament>()
                .HasOne(tt => tt.Tournament)
                .WithMany(t => t.TeamRegistrations)
                .HasForeignKey(tt => tt.TournamentId);

            // Застосовуємо Restrict, щоб не було multiple cascade paths
            builder.Entity<Match>()
                .HasOne(m => m.TeamA)
                .WithMany()
                .HasForeignKey(m => m.TeamAId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Match>()
                .HasOne(m => m.TeamB)
                .WithMany()
                .HasForeignKey(m => m.TeamBId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
