using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using PptkNew.Entities;

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
        return PartialView("~/Views/UserSkpd/AddEdit.cshtml", new UserSkpd());
    }
}