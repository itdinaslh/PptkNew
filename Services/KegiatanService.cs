using PptkNew.Data;
using PptkNew.Entities;
using PptkNew.Repositories;

namespace PptkNew.Services
{
    public class KegiatanService : IKegiatan
    {
        private readonly AppDbContext context;

        public KegiatanService(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Kegiatan> Kegiatans => context.Kegiatans;

#nullable disable

        public async Task SaveKegiatanAsync(Kegiatan kegiatan)
        {
            if (kegiatan.KegiatanId == 0)
            {
                await context.AddAsync(kegiatan);
            } else
            {
                Kegiatan keg = await context.Kegiatans.FindAsync(kegiatan.KegiatanId);

                keg.KodeKegiatan = kegiatan.KodeKegiatan;
                keg.NamaKegiatan = kegiatan.NamaKegiatan;
                keg.UpdatedAt = DateTime.Now;

                context.Update(keg);
            }

            await context.SaveChangesAsync();
        }
    }
}
