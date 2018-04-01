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
            modelBuilder.Entity<Match>().Property<string>("TeamAId").IsRequired();
            modelBuilder.Entity<Match>().Property<string>("TeamBId").IsRequired();
            modelBuilder.Entity<Match>().Property<int>("TournamentId").IsRequired();

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

            modelBuilder.Entity<Group>().Property<int>("TournamentId").IsRequired();
            modelBuilder.Entity<Group>().Property<string>("OwnerId").IsRequired();

            modelBuilder
                .Entity<Group>()
                .HasOne(p => p.Tournament)
                .WithMany()
                .HasForeignKey("TournamentId");

            modelBuilder.Entity<Group>().HasMany(p => p.UserGroups);
            modelBuilder.Entity<Group>().HasOne(p => p.Owner).WithMany().HasForeignKey("OwnerId");

            modelBuilder.Entity<MatchForecast>()
                .HasAlternateKey(p => p.Id);

            modelBuilder.Entity<MatchForecast>().Property<int>("MatchId").IsRequired();
            modelBuilder.Entity<MatchForecast>().Property<string>("UserId").IsRequired();
            modelBuilder.Entity<MatchForecast>().Property<int>("UserGroupId").IsRequired();

            modelBuilder.Entity<MatchForecast>()
                .HasOne(p => p.Match)
                .WithMany()
                .HasForeignKey("MatchId");

            modelBuilder.Entity<MatchForecast>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey("UserId");

            modelBuilder.Entity<MatchForecast>()
                .HasOne(p => p.UserGroup)
                .WithMany()
                .HasForeignKey("UserGroupId");

            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property<string>("TeamId").IsRequired();
            modelBuilder.Entity<User>().HasOne(p => p.SupportedTeam).WithMany().HasForeignKey("TeamId");


            modelBuilder.Entity<UserGroup>().HasKey(p => new { p.GroupId, p.UserId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(p => p.Group)
                .WithMany(p => p.UserGroups)
                .HasForeignKey(p => p.GroupId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserGroups)
                .HasForeignKey(p => p.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseInMemoryDatabase("InMemoryTournamentDb");
                optionsBuilder.UseSqlite("DataSource=core.db");
            }
        }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}