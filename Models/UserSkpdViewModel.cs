using PptkNew.Entities;

namespace PptkNew.Models;

public class UserSkpdViewModel
{
    public UserSkpd? UserSkpd { get; set; } = new UserSkpd();

    public string? SkpdName { get; set; } = string.Empty;
}
