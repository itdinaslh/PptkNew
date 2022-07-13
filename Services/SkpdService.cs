using PptkNew.Data;
using PptkNew.Repositories;
using PptkNew.Entities;

namespace PptkNew.Services;

public class SkpdService : ISkpd {
    private readonly AppDbContext context;

    public SkpdService(AppDbContext ctx) {
        context = ctx;
    }

    public IQueryable<Skpd> Skpds => context.Skpds;
}