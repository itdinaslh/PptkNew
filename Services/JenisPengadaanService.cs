using PptkNew.Repositories;
using PptkNew.Entities;
using PptkNew.Data;
using Microsoft.EntityFrameworkCore;

namespace PptkNew.Services;

public class JenisPengadaanService : IJenisPengadaan
{
    private AppDbContext context;

    public JenisPengadaanService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<JenisPengadaan> JenisPengadaans => context.JenisPengadaans;

#nullable disable
    public async Task SaveDataAsync(JenisPengadaan jenisPengadaan)
    {
        if (jenisPengadaan.JenisPengadaanId == 0)
        {
            await context.AddAsync(jenisPengadaan);
        } else
        {
            JenisPengadaan data = await context.JenisPengadaans.FirstOrDefaultAsync(p => p.JenisPengadaanId == jenisPengadaan.JenisPengadaanId);
            data.NamaJenis = jenisPengadaan.NamaJenis;
            data.UpdatedAt = DateTime.Now;

            context.Update(data);
        }

        await context.SaveChangesAsync();
    }
}
