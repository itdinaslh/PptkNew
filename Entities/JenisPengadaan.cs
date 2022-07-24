using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PptkNew.Entities
{
    [Table("JenisPengadaan")]
    public class JenisPengadaan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JenisPengadaanId { get; set; }

#nullable disable
        
        [Required(ErrorMessage = "Nama Jenis Pengadaan Harus Diisi")]
        [MaxLength(50)]
        public string NamaJenis { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public List<TransKegiatan> TransKegiatans { get; set; }
    }
}
