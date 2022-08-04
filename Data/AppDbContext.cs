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
        public DbSet<Kegiatan> Kegiatans { get; set; }
        public DbSet<SubKegiatan> SubKegiatans { get; set; }
        public DbSet<Rekening> Rekenings { get; set; }
        public DbSet<JenisPengadaan> JenisPengadaans { get; set; }        
        public DbSet<UserSkpd> UserSkpds { get; set; }

        public DbSet<TransKegiatan> TransKegiatans { get; set; }

        public DbSet<TransDetails> TransDetails { get; set; }
    }
}
