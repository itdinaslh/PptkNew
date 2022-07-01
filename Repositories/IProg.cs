using PptkNew.Entities;

namespace PptkNew.Repositories
{
    public interface IProg
    {
        IQueryable<Prog> Progs { get; }

        Task SaveProgAsync(Prog prog);
    }
}
