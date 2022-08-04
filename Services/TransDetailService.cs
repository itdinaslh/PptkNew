using PptkNew.Repositories;
using PptkNew.Entities;
using PptkNew.Data;

namespace PptkNew.Services;

public class TransDetailService : ITransDetails
{
    private readonly AppDbContext context;

    public TransDetailService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<TransDetails> TransDetails => context.TransDetails;

    public async Task SaveDataAsync(TransDetails transDetails)
    {
        if (transDetails.TransDetailId == Guid.Empty)
        {
            transDetails.TransDetailId = Guid.NewGuid();
            await context.AddAsync(transDetails);
        } else
        {
            TransDetails? data = await context.TransDetails.FindAsync(transDetails.TransDetailId);

            if (data is not null)
            {
                data.TransKegiatanId = transDetails.TransKegiatanId;
                data.Anggaran = transDetails.Anggaran;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }            
        }

        await context.SaveChangesAsync();
    }
}
