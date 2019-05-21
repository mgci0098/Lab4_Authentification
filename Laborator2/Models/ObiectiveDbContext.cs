using Lab3.Models;
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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
