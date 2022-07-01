using PptkNew.Entities;

namespace PptkNew.Repositories
{
    public interface ISubKegiatan
    {
        IQueryable<SubKegiatan> SubKegiatans { get; }

        Task SaveDataAsync(SubKegiatan subKegiatan);
    }
}
