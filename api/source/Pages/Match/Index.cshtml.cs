using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FantasyWorldCup.Core.Models;

namespace FantasyWorldCup.Api.Pages.Match
{
    public class IndexModel : PageModel
    {
        private readonly FantasyWorldCup.Core.Models.TournamentContext _context;

        public IndexModel(FantasyWorldCup.Core.Models.TournamentContext context)
        {
            _context = context;
        }

        public List<FantasyWorldCup.Core.Models.Match> Match { get; set; }

        public async Task OnGetAsync(int tournamentId)
        {
            Match = await _context
                .Matches
                .Where(i => i.Tournament.Id == tournamentId)
                .Include(i => i.TeamA)
                .Include(i => i.TeamB)
                .ToListAsync();
        }
    }
}
