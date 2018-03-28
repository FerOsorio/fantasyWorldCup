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
    public class DeleteModel : PageModel
    {
        private readonly FantasyWorldCup.Core.Models.TournamentContext _context;

        public DeleteModel(FantasyWorldCup.Core.Models.TournamentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FantasyWorldCup.Core.Models.Match Match { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match = await _context.Matches.SingleOrDefaultAsync(m => m.Id == id);

            if (Match == null)
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

            Match = await _context.Matches.FindAsync(id);

            if (Match != null)
            {
                _context.Matches.Remove(Match);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
