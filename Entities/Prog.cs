using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PptkNew.Entities
{
    [Table("Program")]
    [Index(nameof(KodeProgram), IsUnique = true)]
    public class Prog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }

#nullable disable
        [Required(ErrorMessage = "Kode Program Harus Diisi")]
        [MaxLength(30)]
        public string KodeProgram { get; set; }

        [Required(ErrorMessage = "Nama Program Harus Diisi")]        
        public string NamaProgram { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public List<TransKegiatan> TransKegiatans { get; set; }
    }
}
