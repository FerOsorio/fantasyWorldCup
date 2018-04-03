namespace FantasyWorldCup.Core.Models
{
    using System;
    using System.Collections.Generic;

    public enum MatchStatus
    {
        NotStarted = 0,
        InProgress = 1, 
        Completed = 2
    }

    public class Tournament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Match> Matches { get; set; }
    }

    public class Match
    {
        public int Id { get; set; }
        
        public DateTimeOffset Schedule { get; set; }

        public Tournament Tournament { get; set; }

        public Team TeamA { get; set; }

        public Team TeamB { get; set; }

        public int TeamAScore { get; set; } = 0;

        public int TeamBScore { get; set; } = 0;

        public MatchStatus Status { get; set; } = MatchStatus.NotStarted;

    }

    public class Team
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Tournament Tournament { get; set; }

        public User Owner { get; set; }

        public List<UserGroup> UserGroups { get; set; }
    }

    public class User
    {
        public string Id { get; set; }

        public Team SupportedTeam { get; set; }

        public List<UserGroup> UserGroups { get; set; }
    }

    public class UserGroup
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
    

    public enum Forecast
    {
        Tie,
        LocalWin,
        VisitorWin
    }

    public class MatchForecast
    {
        public int Id { get; set; }
        
        public User User { get; set; }
        
        public Match Match { get; set; }

        public Forecast Forecast { get; set; }

        public Group UserGroup { get; set; }

        public int TeamAScore { get; set; } = 0;

        public int TeamBScore { get; set; } = 0;
    }
}