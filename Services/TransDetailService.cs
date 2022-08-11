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

    public async Task DeleteDataAsync(Guid? id)
    {
        TransDetails? data = await context.TransDetails.FindAsync(id);

        if (data is not null)
        {
            context.Remove(data);

            await context.SaveChangesAsync();
        }
    }

    public async Task SaveDataAsync(TransDetails transDetails)
    {
        await context.AddAsync(transDetails);        

        await context.SaveChangesAsync();
    }
}
