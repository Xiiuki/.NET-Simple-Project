using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WpfApp_presAPI.Models;

namespace WpfApp_presAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Planete> Planetes { get; set; }
    }
}

