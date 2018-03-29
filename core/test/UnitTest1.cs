namespace FantasyWorldCup.Core.Tests
{
    using System;
    using Xunit;
    using FantasyWorldCup.Core;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class UnitTest1
    {
        [Fact]

        public async Task Test1()
        {
            var options = new DbContextOptionsBuilder<Models.TournamentContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            using (var context = new Models.TournamentContext(options))
            {
                Models.SeedData.InitializeInternal(context);

                var result = await context.Tournaments.AnyAsync();
                Assert.False(result);
            }
        }
    }
}
