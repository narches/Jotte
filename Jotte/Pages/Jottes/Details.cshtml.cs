using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Jotte.Data;
using Jotte.Models;

namespace Jotte.Pages.Jottes
{
    public class DetailsModel : PageModel
    {
        private readonly Jotte.Data.JotteContext _context;

        public DetailsModel(Jotte.Data.JotteContext context)
        {
            _context = context;
        }

      public Sjotte Sjotte { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sjotte == null)
            {
                return NotFound();
            }

            var sjotte = await _context.Sjotte.FirstOrDefaultAsync(m => m.Id == id);
            if (sjotte == null)
            {
                return NotFound();
            }
            else 
            {
                Sjotte = sjotte;
            }
            return Page();
        }
    }
}
