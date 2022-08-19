using PptkNew.Entities;

namespace PptkNew.Models.Transaksi;

public class DetailVM
{
    public TransKegiatan? TransKegiatan { get; set; }

    public TransDetails? TransDetails { get; set; }

    public Kontrak? Kontrak { get; set; }
}
