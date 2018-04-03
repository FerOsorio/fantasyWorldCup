using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FantasyWorldCup.Core.Models;

namespace FantasyWorldCup.Api.Pages.Group
{
    public class DetailsModel : PageModel
    {
        private readonly FantasyWorldCup.Core.Models.TournamentContext _context;

        public DetailsModel(FantasyWorldCup.Core.Models.TournamentContext context)
        {
            _context = context;
        }

        public FantasyWorldCup.Core.Models.Group Group { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Group = await _context.Group.SingleOrDefaultAsync(m => m.Id == id);

            if (Group == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
