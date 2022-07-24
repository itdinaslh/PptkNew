using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using PptkNew.Entities;
using PptkNew.Models;
using PptkNew.Helpers;
using Microsoft.EntityFrameworkCore;

namespace PptkNew.Controllers;

public class UserSkpdController : Controller {
    private readonly IUserSkpd repo;

    public UserSkpdController(IUserSkpd repo) {
        this.repo = repo;
    }

    [HttpGet("/administrator/user-skpd")]
    public IActionResult Index() {
        return View();
    }

    [HttpGet("/administrator/user-skpd/create")]
    public IActionResult Create() {
        return PartialView("~/Views/UserSkpd/AddEdit.cshtml", new UserSkpdViewModel());
    }

    [HttpGet("/administrator/user-skpd/edit")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var data = await repo.UserSkpds.Select(x => new
        {
            x.UserSkpdId,
            x.SkpdId,
            x.UserName,
            x.Skpd.SkpdName
        }).FirstOrDefaultAsync(p => p.UserSkpdId == id);

        if (data is not null)
        {
            return PartialView("~/Views/UserSkpd/AddEdit.cshtml", new UserSkpdViewModel
            {
                UserSkpd = new UserSkpd
                {
                    UserSkpdId = data.UserSkpdId,
                    SkpdId = data.SkpdId,
                    UserName = data.UserName,
                },
                SkpdName = data.SkpdName
            });
        }

        return NotFound();
    }

    [HttpPost("/administrator/user-skpd/store")]
    public async Task<IActionResult> SaveDataAsync(UserSkpdViewModel model)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(model.UserSkpd!);

            return Json(Result.Success());
        }

        return PartialView("~/Views/UserSkpd/AddEdit.cshtml", model);
    }
}