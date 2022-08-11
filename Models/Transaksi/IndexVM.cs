using PptkNew.Entities;

namespace PptkNew.Models.Transaksi;

public class IndexVM
{
    public IEnumerable<TransKegiatan>? TransKegiatans { get; set; }

    public int Tahun { get; set; } = DateTime.Now.Year;

    public double SumAnggaran()
    {
        return TransKegiatans!.Sum(t => t.TransDetails.Sum(e => e.Anggaran));
    }

    public int TotalSub()
    {
        return TransKegiatans!.Sum(t => t.TransDetails.Count);
    }
}
