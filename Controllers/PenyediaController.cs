using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using PptkNew.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using PptkNew.Models.Master;
using PptkNew.Helpers;

namespace PptkNew.Controllers;

[Authorize]
public class PenyediaController : Controller
{
    private readonly IPenyedia repo;

    public PenyediaController(IPenyedia repo)
    {
        this.repo = repo;
    }

    [HttpGet("/master/penyedia")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/master/penyedia/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Penyedia/AddEdit.cshtml", new PenyediaVM());
    }

    [HttpGet("/master/penyedia/edit/")]
    public async Task<IActionResult> Edit(Guid? id)
    {
        Penyedia? data = await repo.Penyedias.FirstOrDefaultAsync(p => p.PenyediaId == id);

        if (data is not null)
        {
            return PartialView("~/Views/Penyedia/AddEdit.cshtml", new PenyediaVM
            {
                Penyedia = data,
                IsNew = false
            });
        }

        return NotFound();
    }

    [HttpPost("/master/penyedia/store")]
    public async Task<IActionResult> Store(PenyediaVM model)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(model);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Penyedia/AddEdit.cshtml", model);
    }
}
