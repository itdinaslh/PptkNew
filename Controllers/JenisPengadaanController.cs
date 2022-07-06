using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PptkNew.Entities;
using PptkNew.Repositories;
using PptkNew.Helpers;

namespace PptkNew.Controllers;

[Authorize]
public class JenisPengadaanController : Controller
{
    private readonly IJenisPengadaan repo;

    public JenisPengadaanController(IJenisPengadaan repo)
    {
        this.repo = repo;
    }

    [HttpGet("/master/jenis-pengadaan")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/master/jenis-pengadaan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/JenisPengadaan/AddEdit.cshtml", new JenisPengadaan());
    }

#nullable disable

    [HttpGet("/master/jenis-pengadaan/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        JenisPengadaan data = await repo.JenisPengadaans.FirstOrDefaultAsync(j => j.JenisPengadaanId == id);

        return PartialView("~/Views/JenisPengadaan/AddEdit.cshtml", data);
    }

    [HttpPost("/master/jenis-pengadaan/store")]
    public async Task<IActionResult> SaveDataAsync(JenisPengadaan jenis)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(jenis);

            return Json(Result.Success());
        }

        return PartialView("~/Views/JenisPengadaan/AddEdit.cshtml", jenis);
    }
}
