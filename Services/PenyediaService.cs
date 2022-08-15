using PptkNew.Repositories;
using PptkNew.Data;
using PptkNew.Entities;
using PptkNew.Models.Master;

namespace PptkNew.Services;

public class PenyediaService : IPenyedia
{
    private readonly AppDbContext context;

    public PenyediaService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Penyedia> Penyedias => context.Penyedias;

    public async Task SaveDataAsync(PenyediaVM model)
    {
        if (model.IsNew)
        {
            await context.AddAsync(model.Penyedia);
        } else
        {
            Penyedia? data = await context.Penyedias.FindAsync(model.Penyedia.PenyediaId);

            if (data is not null)
            {
                data.NamaPenyedia = model.Penyedia.NamaPenyedia;
                data.NPWP = model.Penyedia.NPWP;
                data.Alamat = model.Penyedia.Alamat;
                data.
            }
        }
    }
}
