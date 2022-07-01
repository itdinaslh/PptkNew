using Microsoft.EntityFrameworkCore;
using PptkNew.Entities;

namespace PptkNew.Data
{
    public class AppDbContext : DbContext
    {
        #nullable disable
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Skpd> Skpds { get; set; }
        public DbSet<Prog> Progs { get; set; }
        
    }
}
