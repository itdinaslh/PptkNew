using PptkNew.Entities;

namespace PptkNew.Repositories;

public interface ITransDetails
{
    IQueryable<TransDetails> TransDetails { get; }

    IQueryable<Kontrak> Kontraks { get; }

    Task SaveDataAsync(TransDetails transDetails);

    Task UpdateDataAsync(TransDetails details);

    Task SaveKontrakAsync(Kontrak kontrak);

    Task DeleteDataAsync(Guid? id);
}
