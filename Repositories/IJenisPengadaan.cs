using PptkNew.Entities;

namespace PptkNew.Repositories;

public interface IJenisPengadaan
{
    IQueryable<JenisPengadaan> JenisPengadaans { get; }

    Task SaveDataAsync(JenisPengadaan jenisPengadaan);
}
