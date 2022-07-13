using PptkNew.Entities;
using PptkNew.Data;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PptkNew.Services;

public class UserSkpdService : IUserSkpd {
    private readonly AppDbContext context;

    public UserSkpdService(AppDbContext ctx) => context = ctx;

    public IQueryable<UserSkpd> UserSkpds => context.UserSkpds;

    public async Task SaveDataAsync(UserSkpd us) {
        if (us.UserSkpdId == Guid.Empty) {
            await context.AddAsync(us);
        } else {
            UserSkpd? data = await context.UserSkpds.FindAsync(us.UserSkpdId);

            if (data is not null) {
                data.SkpdId = us.SkpdId;
                data.UserName = us.UserName;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}