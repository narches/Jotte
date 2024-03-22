using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Jotte.Data;
using Jotte.Models;

namespace Jotte.Pages.Jottes
{
    public class CreateModel : PageModel
    {
        private readonly Jotte.Data.JotteContext _context;

        public CreateModel(Jotte.Data.JotteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sjotte Sjotte { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sjotte == null || Sjotte == null)
            {
                return Page();
            }

            _context.Sjotte.Add(Sjotte);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
