using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FantasyWorldCup.Core.Models;

namespace FantasyWorldCup.Api.Pages.Match
{
    public class EditModel : PageModel
    {
        private readonly FantasyWorldCup.Core.Models.TournamentContext _context;

        public EditModel(FantasyWorldCup.Core.Models.TournamentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FantasyWorldCup.Core.Models.Match Match { get; set; }

        public IEnumerable<SelectListItem> SelectListTeamA { get; set; }
        public IEnumerable<SelectListItem> SelectListTeamB { get; set; }

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

            var teams = await _context.Teams.ToListAsync();

            SelectListTeamA = teams.Select(i => new SelectListItem
            {
                Value = i.Id,
                Text = i.Name,
                Selected = i.Id.Equals(Match.TeamA.Id, StringComparison.InvariantCultureIgnoreCase)
            });

            SelectListTeamB = teams.Select(i => new SelectListItem
            {
                Value = i.Id,
                Text = i.Name,
                Selected = i.Id.Equals(Match.TeamB.Id, StringComparison.InvariantCultureIgnoreCase)
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(Match.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
