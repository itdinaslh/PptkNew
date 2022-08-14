using Microsoft.AspNetCore.Mvc;
using PptkNew.Repositories;
using PptkNew.Entities;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers;

[Authorize]
public class PenyediaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
