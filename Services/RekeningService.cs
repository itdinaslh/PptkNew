using PptkNew.Entities;
using PptkNew.Data;
using Microsoft.EntityFrameworkCore;
using PptkNew.Repositories;

namespace PptkNew.Services;

public class RekeningService : IRekening
{
    private readonly AppDbContext context;

    public RekeningService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Rekening> Rekenings => context.Rekenings;

#nullable disable

    public async Task SaveDataAsync(Rekening rek)
    {
        if (rek.RekeningId == 0)
        {
            await context.AddAsync(rek);
        } else
        {
            Rekening data = await context.Rekenings.FindAsync(rek.RekeningId);

            data.KodeRekening = rek.KodeRekening;
            data.NamaRekening = rek.NamaRekening;
            data.UpdatedAt = DateTime.Now;

            context.Update(data);
        }

        await context.SaveChangesAsync();
    }
}