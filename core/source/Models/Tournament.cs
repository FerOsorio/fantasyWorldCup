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
}