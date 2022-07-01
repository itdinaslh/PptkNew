using PptkNew.Entities;

namespace PptkNew.Repositories
{
    public interface IKegiatan
    {
        IQueryable<Kegiatan> Kegiatans { get; }

        Task SaveKegiatanAsync(Kegiatan kegiatan);
    }
}
