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
    public class IndexModel : PageModel
    {
        private readonly Jotte.Data.JotteContext _context;

        public IndexModel(Jotte.Data.JotteContext context)
        {
            _context = context;
        }

        public IList<Sjotte> Sjotte { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sjotte != null)
            {
                Sjotte = await _context.Sjotte.ToListAsync();
            }
        }
    }
}
