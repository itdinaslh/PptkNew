using PptkNew.Entities;
using PptkNew.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PptkNew.Models.Transaksi;

namespace PptkNew.Controllers;

public class TransKegiatanController : Controller
{
    private readonly ITransKegiatan repo;

    public TransKegiatanController(ITransKegiatan repo)
    {
        this.repo = repo;
    }

    [HttpGet("/transaksi/index")]
    public IActionResult Index(int? query)
    {
        int? curYear = query == null ? DateTime.Now.Year : query;
        IQueryable<TransKegiatan>? transKegiatans = repo.TransKegiatans
            .Where(t => t.Tahun == curYear)
            .Where(sk => sk.SkpdId == 1)
            .Include(s => s.SubKegiatan)
            .Include(k => k.SubKegiatan.Kegiatan)
            .Include(p => p.Prog);
        return View(new IndexVM { TransKegiatans = transKegiatans});
    }

    [HttpGet("/transaksi/detail")]
    public IActionResult Detail() {
        return View(new DetailVM());
    }
}
