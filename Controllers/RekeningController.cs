using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PptkNew.Entities;
using PptkNew.Repositories;
using PptkNew.Helpers;

namespace PptkNew.Controllers;

[Authorize]
public class RekeningController : Controller
{
    private readonly IRekening repo;

    public RekeningController(IRekening repo)
    {
        this.repo = repo;
    }

    [HttpGet("/master/rekening")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/master/rekening/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Rekening/AddEdit.cshtml", new Rekening());
    }

#nullable disable

    [HttpGet("/master/rekening/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        Rekening data = await repo.Rekenings.FirstOrDefaultAsync(r => r.RekeningId == id);

        return PartialView("~/Views/Rekening/AddEdit.cshtml", data);
    }

    [HttpPost("/master/rekening/store")]
    public async Task<IActionResult> SaveDataAsync(Rekening rek)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(rek);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Rekening/AddEdit.cshtml", rek);
    }
}