using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PptkNew.Models;
using Microsoft.AspNetCore.Authorization;

namespace PptkNew.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/dashboard")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/")]
    public IActionResult Main() {
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
