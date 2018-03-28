using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FantasyWorldCup.Core.Models;

namespace FantasyWorldCup.Api.Pages.Match
{
    public class CreateModel : PageModel
    {
        private readonly FantasyWorldCup.Core.Models.TournamentContext _context;

        public CreateModel(FantasyWorldCup.Core.Models.TournamentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FantasyWorldCup.Core.Models.Match Match { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Matches.Add(Match);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}