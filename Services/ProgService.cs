using PptkNew.Entities;
using PptkNew.Data;
using PptkNew.Repositories;

namespace PptkNew.Services
{
    public class ProgService : IProg
    {
        private AppDbContext context;

        public ProgService(AppDbContext ctx) => context = ctx;

        public IQueryable<Prog> Progs => context.Progs;

        public async Task SaveProgAsync(Prog prog)
        {
            if (prog.ProgramId == 0)
            {
                await context.AddAsync(prog);
            } else
            {
                var data = await context.Progs.FindAsync(prog.ProgramId);

                if (data is not null)
                {
                    data.KodeProgram = prog.KodeProgram;
                    data.NamaProgram = prog.NamaProgram;

                    prog.UpdatedAt = DateTime.Now;

                    context.Update(data);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
