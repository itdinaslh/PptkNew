using PptkNew.Entities;

namespace PptkNew.Models.Transaksi;

public class IndexVM
{
    public IEnumerable<TransKegiatan>? TransKegiatans { get; set; }

    public int Tahun { get; set; } = DateTime.Now.Year;
    
}
