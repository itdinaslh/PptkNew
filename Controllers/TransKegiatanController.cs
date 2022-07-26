using PptkNew.Entities;
using PptkNew.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PptkNew.Controllers;

public class TransKegiatanController : Controller
{
    private readonly ITransKegiatan repo;

    public TransKegiatanController(ITransKegiatan repo)
    {
        this.repo = repo;
    }

    [HttpGet("/transaksi/index")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/transaksi/detail")]
    public IActionResult Detail() {
        return View();
    }
}
