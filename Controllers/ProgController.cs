using Microsoft.AspNetCore.Mvc;

namespace PptkNew.Controllers
{
    public class ProgController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
