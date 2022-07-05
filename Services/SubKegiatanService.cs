using PptkNew.Data;
using PptkNew.Entities;
using PptkNew.Repositories;

namespace PptkNew.Services
{
    public class SubKegiatanService : ISubKegiatan
    {
        private readonly AppDbContext context;

        public SubKegiatanService(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<SubKegiatan> SubKegiatans => context.SubKegiatans;

#nullable disable

        public async Task SaveDataAsync(SubKegiatan subKegiatan)
        {
            if (subKegiatan.SubKegiatanId == 0)
            {
                await context.AddAsync(subKegiatan);
            } else
            {
                SubKegiatan data = await context.SubKegiatans.FindAsync(subKegiatan.SubKegiatanId);

                data.NamaSubKegiatan = subKegiatan.NamaSubKegiatan;
                data.IsDeleted = subKegiatan.IsDeleted;
                data.KodeSubKegiatan = subKegiatan.KodeSubKegiatan;
                data.KegiatanId = subKegiatan.KegiatanId;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }

            await context.SaveChangesAsync();
        }
    }
}
