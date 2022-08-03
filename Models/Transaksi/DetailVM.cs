using PptkNew.Entities;

namespace PptkNew.Models.Transaksi;

public class DetailVM
{
    public TransKegiatan? TransKegiatan { get; set; }

    public IEnumerable<TransDetails>? TransDetails { get; set; }

    public double ComputeTotal() =>
        TransDetails!.Sum(p => p.Anggaran);
}
