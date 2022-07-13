using PptkNew.Entities;

namespace PptkNew.Repositories;

public interface ISkpd {
    IQueryable<Skpd> Skpds { get; }
}