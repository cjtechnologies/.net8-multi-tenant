using Microsoft.EntityFrameworkCore;
using MultiTenant.Models;
using System.Collections.Generic;

namespace MultiTenant.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
