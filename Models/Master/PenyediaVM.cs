using PptkNew.Entities;

namespace PptkNew.Models.Master;

public class PenyediaVM
{
#nullable disable
    public Penyedia Penyedia { get; set; } = new Penyedia();

    public bool IsNew { get; set; } = true;
}
