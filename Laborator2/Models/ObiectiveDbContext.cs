using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator2.Models
{
    public class ObiectiveDbContext : DbContext
    {
        public ObiectiveDbContext(DbContextOptions<ObiectiveDbContext> options) : base(options)
        {
        }

        public DbSet<Obiectiv> Obiective { get; set; }

    }
}
