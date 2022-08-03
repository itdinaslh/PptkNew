using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PptkNew.Entities;

[Table("TransDetails")]
public class TransDetails
{
#nullable disable
    [Key]
    public Guid TransDetailId { get; set; } = Guid.NewGuid();

    [Required]
    public long TransKegiatanId { get; set; }

    [Required]
    public int RekeningId { get; set; }

    public double Anggaran { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public TransKegiatan TransKegiatan { get; set; }

    public Rekening Rekening { get; set; }
}
