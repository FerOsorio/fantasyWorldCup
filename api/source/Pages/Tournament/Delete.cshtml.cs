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
    public class DeleteModel : PageModel
    {
        private readonly FantasyWorldCup.Core.Models.TournamentContext _context;

        public DeleteModel(FantasyWorldCup.Core.Models.TournamentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FantasyWorldCup.Core.Models.Tournament Tournament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournament = await _context.Tournaments.SingleOrDefaultAsync(m => m.Id == id);

            if (Tournament == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournament = await _context.Tournaments.FindAsync(id);

            if (Tournament != null)
            {
                _context.Tournaments.Remove(Tournament);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
