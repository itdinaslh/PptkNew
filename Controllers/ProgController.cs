using Microsoft.AspNetCore.Mvc;
using PptkNew.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PptkNew.Repositories;
using PptkNew.Helpers;

namespace PptkNew.Controllers;

[Authorize]
public class ProgController : Controller
{
    private IProg repo;

    public ProgController(IProg prog) => repo = prog;

    [HttpGet("/master/program")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/master/program/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Prog/AddEdit.cshtml", new Prog());
    }

#nullable disable

    [HttpGet("/master/program/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        Prog data = await repo.Progs.FirstOrDefaultAsync(p => p.ProgramId == id);

        return PartialView("~/Views/Prog/AddEdit.cshtml", data);
    }

    [HttpPost("/master/program/store")]
    public async Task<IActionResult> SaveDataAsync(Prog myProg)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveProgAsync(myProg);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Prog/AddEdit.cshtml", myProg);
    }
}