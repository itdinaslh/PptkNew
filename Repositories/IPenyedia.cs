using PptkNew.Entities;
using PptkNew.Models.Master;

namespace PptkNew.Repositories;

public interface IPenyedia
{
    IQueryable<Penyedia> Penyedias { get; }

    Task SaveDataAsync(PenyediaVM model);

}
