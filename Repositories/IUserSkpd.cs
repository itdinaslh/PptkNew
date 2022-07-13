using PptkNew.Entities;

namespace PptkNew.Repositories;

public interface IUserSkpd {
    IQueryable<UserSkpd> UserSkpds { get; }

    Task SaveDataAsync(UserSkpd us);
}