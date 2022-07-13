using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PptkNew.Entities
{
    [Table("Skpd")]
    [Index(nameof(SkpdCode), IsUnique = true)]
    public class Skpd
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkpdId { get; set; }

        #nullable disable
        [Required(ErrorMessage = "Kode SKPD Wajib Diisi")]
        [MaxLength(25)]
        
        public string SkpdCode { get; set; }

        [Required(ErrorMessage = "Nama SKPD Wajib Diisi")]
        [MaxLength(250)]
        public string SkpdName { get; set; }

#nullable enable
        [MaxLength(100)]
        public string? NamaPimpinan { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int? ParentId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        #nullable disable

        public List<UserSkpd> UserSkpds { get; set; }
    }
}
