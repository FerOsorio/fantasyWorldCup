using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FantasyWorldCup.Core.Models;

namespace FantasyWorldCup.Api.Pages.Team
{
    public class DeleteModel : PageModel
    {
        private readonly FantasyWorldCup.Core.Models.TournamentContext _context;

        public DeleteModel(FantasyWorldCup.Core.Models.TournamentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FantasyWorldCup.Core.Models.Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Teams.SingleOrDefaultAsync(m => m.Id == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Teams.FindAsync(id);

            if (Team != null)
            {
                _context.Teams.Remove(Team);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
