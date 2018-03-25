namespace FantasyWorldCup.Core.Models
{
    using System.Collections.Generic;

    public class Tournament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Match> Matches { get; set; }
    }

    public enum MatchStatus
    {
        NotStarted = 0,
        InProgress = 1, 
        Completed = 2
    }

    public class Match
    {
        public int Id { get; set; }

        public Team Local { get; set; }

        public Team Visitor { get; set; }

        public int LocalTeamScore { get; set; } = 0;

        public int VisitorTeamScore { get; set; } = 0;

        public MatchStatus Status { get; set; }
    }

    public class Team
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}