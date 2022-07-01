using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PptkNew.Entities
{
    [Table("SubKegiatan")]
    [Index(nameof(KodeSubKegiatan), IsUnique = true)]
    public class SubKegiatan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubKegiatanId { get; set; }

#nullable disable

        [Required(ErrorMessage = "Kode Sub Kegiatan Wajib Diisi")]
        [MaxLength(30)]
        public string KodeSubKegiatan { get; set; }

        [Required(ErrorMessage = "Nama Sub Kegiatan Wajib Diisi")]
        public string NamaSubKegiatan { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
