namespace FantasyWorldCup.Core.Models
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options)
            : base(options)
        {
        }

        public TournamentContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>().HasKey(p => p.Id);
            modelBuilder.Entity<Tournament>().HasMany(p => p.Matches).WithOne(p => p.Tournament);

            modelBuilder.Entity<Match>().HasKey(p => p.Id);
            modelBuilder.Entity<Match>().Property<string>("TeamAId");
            modelBuilder.Entity<Match>().Property<string>("TeamBId");
            modelBuilder.Entity<Match>().Property<int>("TournamentId");

            modelBuilder
                .Entity<Match>()
                .HasOne(p => p.TeamA);

            modelBuilder
                .Entity<Match>()
                .HasOne(p => p.TeamB);

            modelBuilder
                .Entity<Match>()
                .HasOne(p => p.Tournament)
                .WithMany(p => p.Matches)
                .HasForeignKey("TournamentId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryTournamentDb");
            }
        }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}