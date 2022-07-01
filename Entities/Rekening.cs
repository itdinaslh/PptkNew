using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PptkNew.Entities
{
    [Table("Rekening")]
    [Index(nameof(KodeRekening), IsUnique = true)]
    public class Rekening
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RekeningId { get; set; }

#nullable disable

        [Required(ErrorMessage = "Kode Rekening Harus Diisi")]
        [MaxLength(50)]
        public string KodeRekening { get; set; }

        [Required(ErrorMessage = "Nama Rekening Harus Diisi")]
        [MaxLength(255)]
        public string NamaRekening { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
