using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jotte.Data;
using Jotte.Models;

namespace Jotte.Pages.Jottes
{
    public class EditModel : PageModel
    {
        private readonly Jotte.Data.JotteContext _context;

        public EditModel(Jotte.Data.JotteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sjotte Sjotte { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sjotte == null)
            {
                return NotFound();
            }

            var sjotte =  await _context.Sjotte.FirstOrDefaultAsync(m => m.Id == id);
            if (sjotte == null)
            {
                return NotFound();
            }
            Sjotte = sjotte;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sjotte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SjotteExists(Sjotte.Id))
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

        private bool SjotteExists(int id)
        {
          return (_context.Sjotte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
