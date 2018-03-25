namespace FantasyWorldCup.Core.Models
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class TournamentContext : DbContext
    {
        // public TournamentContext(DbContextOptions<TournamentContext> options)
        //     : base(options)
        // {
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Tournament>()
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<Match>()
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<Team>()
                .HasKey(p => p.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tournaments.db");
        }

        public DbSet<Tournament> Tournaments { get; set; }
    }
}