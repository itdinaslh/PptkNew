using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using PptkNew.Repositories;
using PptkNew.Entities;
using PptkNew.Helpers;

namespace PptkNew.Controllers;

[Authorize]
public class KegiatanController : Controller
{
    private IKegiatan repo;

    public KegiatanController(IKegiatan kegiatan) => repo = kegiatan;

    [HttpGet("/master/kegiatan")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/master/kegiatan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Kegiatan/AddEdit.cshtml", new Kegiatan());
    }

#nullable disable

    [HttpGet("/master/kegiatan/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        Kegiatan kegiatan = await repo.Kegiatans.FirstOrDefaultAsync(k => k.KegiatanId == id);

        return PartialView("~/Views/Kegiatan/AddEdit.cshtml", kegiatan);
    }

    [HttpPost("/master/kegiatan/store")]
    public async Task<IActionResult> SaveDataAsync(Kegiatan kegiatan)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveKegiatanAsync(kegiatan);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Kegiatan/AddEdit.cshtml", kegiatan);
    }
}
