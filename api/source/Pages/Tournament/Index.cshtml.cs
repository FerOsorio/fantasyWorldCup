using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FantasyWorldCup.Core.Models;

namespace FantasyWorldCup.Api.Pages.Tournament
{
    public class IndexModel : PageModel
    {
        private readonly FantasyWorldCup.Core.Models.TournamentContext _context;

        public IndexModel(FantasyWorldCup.Core.Models.TournamentContext context)
        {
            _context = context;
        }

        public IList<FantasyWorldCup.Core.Models.Tournament> Tournament { get;set; }

        public async Task OnGetAsync()
        {
            Tournament = await _context.Tournaments.ToListAsync();
        }
    }
}
