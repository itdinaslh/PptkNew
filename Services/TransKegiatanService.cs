using PptkNew.Data;
using PptkNew.Entities;
using PptkNew.Repositories;

namespace PptkNew.Services;

public class TransKegiatanService : ITransKegiatan {
    private readonly AppDbContext context;

    public TransKegiatanService(AppDbContext ctx) => context = ctx;

    public IQueryable<TransKegiatan> TransKegiatans => context.TransKegiatans;

    public async Task SaveDataAsync(TransKegiatan trans) {
        if (trans.TransKegiatanId == 0) {
            await context.AddAsync(trans);
        }

        await context.SaveChangesAsync();
    }
}