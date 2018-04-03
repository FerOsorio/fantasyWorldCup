using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FantasyWorldCup.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webhost = BuildWebHost(args);

            using (var serviceProviderScope = webhost.Services.CreateScope())
            {
                var serviceProvider = serviceProviderScope.ServiceProvider;
                try
                {
                    var tournamentContext = serviceProvider.GetRequiredService<FantasyWorldCup.Core.Models.TournamentContext>();

                    tournamentContext.Database.Migrate();
                    FantasyWorldCup.Core.Models.SeedData.InitializeInternal(tournamentContext);
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the database.");
                }

            }

            webhost.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
