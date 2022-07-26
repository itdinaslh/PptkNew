using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PptkNew.Repositories;
using PptkNew.Entities;
using PptkNew.Models;
using PptkNew.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers;

[Authorize]
public class SubKegiatanController : Controller
{
    private ISubKegiatan repo;

    public SubKegiatanController(ISubKegiatan sRepo) => repo = sRepo;

    [HttpGet("/master/subkegiatan")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/master/subkegiatan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/SubKegiatan/AddEdit.cshtml", new SubKegiatanViewModel
        {
            SubKegiatan = new SubKegiatan(),
            NamaKegiatan = String.Empty
        });
    }

    [HttpGet("/master/subkegiatan/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        SubKegiatan? sub = await repo.SubKegiatans.FirstOrDefaultAsync(s => s.SubKegiatanId == id);

        if (sub is not null) {
            return PartialView("~/Views/SubKegiatan/AddEdit.cshtml", new SubKegiatanViewModel
            {
                SubKegiatan = sub,
                NamaKegiatan = sub.Kegiatan.NamaKegiatan
            });
        }

        return NotFound();
    }

    [HttpPost("/master/subkegiatan/store")]
    public async Task<IActionResult> SaveDataAsync(SubKegiatanViewModel vm)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(vm.SubKegiatan);

            return Json(Result.Success());
        }

        return PartialView("~/Views/SubKegiatan/AddEdit.cshtml", vm);
    }
}
