using Microsoft.AspNetCore.Mvc;

namespace PptkNew.Controllers
{
    public class ProgController : Controller
    {
        [HttpGet("/master/program")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
