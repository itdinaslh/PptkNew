﻿using PptkNew.Repositories;
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

    public IQueryable<Kontrak> Kontraks => context.Kontraks;

    public async Task DeleteDataAsync(Guid? id)
    {
        TransDetails? data = await context.TransDetails.FindAsync(id);

        if (data is not null)
        {
            context.Remove(data);

            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteKontrakAsync(Guid? id)
    {
        Kontrak? data = await context.Kontraks.FindAsync(id);

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

    public async Task UpdateDataAsync(TransDetails detail)
    {
        TransDetails? data = await context.TransDetails.FindAsync(detail.TransDetailId);

        if (data is not null)
        {
            data.RekeningId = detail.RekeningId;
            data.Anggaran = detail.Anggaran;
            data.UpdatedAt = DateTime.Now;

            context.Update(data);

            await context.SaveChangesAsync();
        }
    }

    public async Task SaveKontrakAsync(Kontrak kontrak)
    {
        await context.AddAsync(kontrak);

        await context.SaveChangesAsync();
    }
 }
