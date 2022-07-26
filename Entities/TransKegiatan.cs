using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PptkNew.Entities;

[Table("TransKegiatan")]
public class TransKegiatan {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long TransKegiatanId { get; set; }

    public int SkpdId { get; set; }

    public int ProgId { get; set; }    

    public int SubKegiatanId { get; set; }

    #nullable disable

    [Required(ErrorMessage = "Kode PASK Wajib Diisi")]
    [MaxLength(50)]
    public string KodePASK { get; set; }

    [Required(ErrorMessage = "Penjabaran atas sub kegiatan wajib diisi")]
    [MaxLength(255)]
    public string Penjabaran { get; set; }

    public int RekeningId { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public Skpd Skpd { get; set; }

    public Prog Prog { get; set; }    

    public SubKegiatan SubKegiatan { get; set; }

    public Rekening Rekening { get; set; }
}