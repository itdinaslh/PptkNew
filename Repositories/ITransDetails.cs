using PptkNew.Entities;

namespace PptkNew.Repositories;

public interface ITransDetails
{
    IQueryable<TransDetails> TransDetails { get; }

    Task SaveDataAsync(TransDetails transDetails);

    Task UpdateDataAsync(TransDetails details);

    Task DeleteDataAsync(Guid? id);
}
