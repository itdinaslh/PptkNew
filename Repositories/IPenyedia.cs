using PptkNew.Entities;

namespace PptkNew.Repositories;

public interface IPenyedia
{
    IQueryable<Penyedia> Penyedias { get; }

    Task SaveDataAsync(Penyedia penyedia);

}
