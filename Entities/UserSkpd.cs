using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PptkNew.Entities;

[Table("UserSkpd")]
public class UserSkpd {
    public Guid UserSkpdId { get; set; } = Guid.Empty;

    public int SkpdId { get; set; }

    #nullable disable
    [Required(ErrorMessage = "Username harus diisi")]
    [MaxLength(255)]
    public string UserName { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public Skpd Skpd { get; set; }
}