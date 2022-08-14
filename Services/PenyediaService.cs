using PptkNew.Repositories;
using PptkNew.Data;
using PptkNew.Entities;

namespace PptkNew.Services;

public class PenyediaService : IPenyedia
{
    private readonly AppDbContext context;

    public PenyediaService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Penyedia> Penyedias => context.Penyedias;

    public Task SaveDataAsync(Penyedia penyedia)
    {
        throw new NotImplementedException();
    }
}
