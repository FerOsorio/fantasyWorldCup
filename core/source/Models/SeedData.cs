namespace FantasyWorldCup.Core.Models
{
    using System;
    using System.Threading;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class SeedData
    {
        public static void InitializeInternal(TournamentContext context)
        {
            if (context.Tournaments.Any())
            {
                return;
            }

            var team_arg = new Team { Id = "arg", Name = "Argentina" };
            var team_aus = new Team { Id = "aus", Name = "Australia" };
            var team_bel = new Team { Id = "bel", Name = "Belgium" };
            var team_bra = new Team { Id = "bra", Name = "Brazil" };
            var team_col = new Team { Id = "col", Name = "Colombia" };
            var team_crc = new Team { Id = "crc", Name = "Costa Rica" };
            var team_cro = new Team { Id = "cro", Name = "Croatia" };
            var team_den = new Team { Id = "den", Name = "Denmark" };
            var team_egy = new Team { Id = "egy", Name = "Egypt" };
            var team_eng = new Team { Id = "eng", Name = "England" };
            var team_esp = new Team { Id = "esp", Name = "Spain" };
            var team_fra = new Team { Id = "fra", Name = "France" };
            var team_ger = new Team { Id = "ger", Name = "Germany" };
            var team_irn = new Team { Id = "irn", Name = "IR Iran" };
            var team_isl = new Team { Id = "isl", Name = "Island" };
            var team_jpn = new Team { Id = "jpn", Name = "Japan" };
            var team_kor = new Team { Id = "kor", Name = "Korea" };
            var team_ksa = new Team { Id = "ksa", Name = "Saudi Arabia" };
            var team_mar = new Team { Id = "mar", Name = "Morocco" };
            var team_mex = new Team { Id = "mex", Name = "Mexico" };
            var team_nga = new Team { Id = "nga", Name = "Nigeria" };
            var team_pan = new Team { Id = "pan", Name = "Panama" };
            var team_per = new Team { Id = "per", Name = "Peru" };
            var team_pol = new Team { Id = "pol", Name = "Poland" };
            var team_por = new Team { Id = "por", Name = "Portugal" };
            var team_rus = new Team { Id = "rus", Name = "Russia" };
            var team_sen = new Team { Id = "sen", Name = "Senegal" };
            var team_srb = new Team { Id = "srb", Name = "Serbia" };
            var team_sui = new Team { Id = "sui", Name = "Switzerland" };
            var team_swe = new Team { Id = "swe", Name = "Sweden" };
            var team_tun = new Team { Id = "tun", Name = "Tunisia" };
            var team_uru = new Team { Id = "uru", Name = "Uruguay" };

            context.Teams.AddRange(
                team_arg,
                team_aus,
                team_bel,
                team_bra,
                team_col,
                team_crc,
                team_cro,
                team_den,
                team_egy,
                team_eng,
                team_esp,
                team_fra,
                team_ger,
                team_irn,
                team_isl,
                team_jpn,
                team_kor,
                team_ksa,
                team_mar,
                team_mex,
                team_nga,
                team_pan,
                team_per,
                team_pol,
                team_por,
                team_rus,
                team_sen,
                team_srb,
                team_sui,
                team_swe,
                team_tun,
                team_uru
            );

            var timeZone_moscu = TimeSpan.FromHours(3);
            var timeZone_saintPetersburg = TimeSpan.FromHours(3);
            var timeZone_sochi = TimeSpan.FromHours(3);
            var timeZone_ekaterinburg = TimeSpan.FromHours(5);

            var matches = new List<Match>
            {
                // June 14
                new Match { TeamA = team_rus, TeamB = team_ksa, Schedule = new DateTimeOffset(2018, 06, 14, 18, 0, 0, 0, timeZone_moscu) },

                // June 15
                new Match { TeamA = team_egy, TeamB = team_uru, Schedule = new DateTimeOffset(2018, 06, 15, 17, 0, 0, 0, timeZone_ekaterinburg) },
                new Match { TeamA = team_mar, TeamB = team_irn, Schedule = new DateTimeOffset(2018, 06, 15, 18, 0, 0, 0, timeZone_saintPetersburg) },
                new Match { TeamA = team_por, TeamB = team_esp, Schedule = new DateTimeOffset(2018, 06, 15, 21, 0, 0, 0, timeZone_sochi) },

                
            };

            var tournament_russia2018 = new Tournament 
            {
                Name = "Russia 2018",
                Matches = matches
            };

            context.Tournaments.Add(tournament_russia2018);

            context.SaveChanges();
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TournamentContext(
                serviceProvider.GetRequiredService<DbContextOptions<TournamentContext>>()))
            {
                InitializeInternal(context);
            }
        }
    }
}