using PptkNew.Entities;

namespace PptkNew.Repositories;

public interface ITransKegiatan {
    IQueryable<TransKegiatan> TransKegiatans { get; }

    Task SaveDataAsync(TransKegiatan trans);
}