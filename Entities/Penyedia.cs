using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PptkNew.Entities;

[Table("Penyedia")]
public class Penyedia
{
    [Key]
    public Guid PenyediaId { get; set; } = Guid.NewGuid();

#nullable disable

    [Required(ErrorMessage = "Nama penyedia wajib diisi!")]
    [MaxLength(200)]
    public string NamaPenyedia { get; set; }

#nullable enable

    public string? Alamat { get; set; }

    [MaxLength(50)]
    public string? NPWP { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long RowId { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}
