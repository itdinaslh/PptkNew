using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PptkNew.Entities
{
    [Table("Kegiatan")]
    [Index(nameof(KodeKegiatan), IsUnique = true)]
    public class Kegiatan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KegiatanId { get; set; }

#nullable disable
        [Required(ErrorMessage = "Kode Kegiatan Harus Diisi")]
        [MaxLength(30)]
        public string KodeKegiatan { get; set; }

        [Required(ErrorMessage = "Nama Kegiatan Harus Diisi")]
        [MaxLength(30)]
        public string NamaKegiatan { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<SubKegiatan> SubKegiatans { get; set; }

    }
}
