using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jotte.Models;

namespace Jotte.Data
{
    public class JotteContext : DbContext
    {
        public JotteContext (DbContextOptions<JotteContext> options)
            : base(options)
        {
        }

        public DbSet<Jotte.Models.Sjotte> Sjotte { get; set; } = default!;
    }
}
