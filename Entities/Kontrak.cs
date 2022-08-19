using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PptkNew.Entities;

[Table("Kontrak")]
public class Kontrak
{
    [Key]
    public Guid KontrakId { get; set; } = Guid.NewGuid();

#nullable disable

    [Required]
    public long TransKegiatanId { get; set; }

    [Required]
    public Guid PenyediaId { get; set; }

    [MaxLength(100)]
    [Required(ErrorMessage = "No Kontrak Wajib Diisi!")]
    public string NoKontrak { get; set; }

    [Required(ErrorMessage = "Tanggal Mulai Kontrak Wajib Diisi!")]

#nullable enable

    [MaxLength(50)]
    public string? KodeRUP { get; set; }

    public Double? NilaiKontrak { get; set; }

    public Double? NilaiKAK { get; set; }

    public Double? NilaiRAB { get; set; }

    public Double? NilaiHPS { get; set; }

    [Required(ErrorMessage = "Tanggal Mulai Kontrak Wajib Diisi")]
    public DateOnly TglMulai { get; set; }

    [Required(ErrorMessage = "Tanggal Berakhir Kontrak Wajib Diisi!")]
    public DateOnly TglBerakhir { get; set; }

    [Required(ErrorMessage = "Jenis Pengadaan Wajib Diisi")]
    public int JenisPengadaanId { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

#nullable disable

    public TransKegiatan TransKegiatan { get; set; }

    public JenisPengadaan JenisPengadaan { get; set; }

    public Penyedia Penyedia { get; set; }

}
