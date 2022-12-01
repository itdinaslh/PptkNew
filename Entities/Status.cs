using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PptkNew.Entities;

[Table("Status")]
public class Status
{
#nullable disable

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StatusId { get; set; }

    [MaxLength(50)]
    public string StatusName { get; set; }
}
