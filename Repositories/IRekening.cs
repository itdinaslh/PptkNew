using PptkNew.Entities;

namespace PptkNew.Repositories;

public interface IRekening
{
    IQueryable<Rekening> Rekenings { get; }

    Task SaveDataAsync(Rekening rekening);
}