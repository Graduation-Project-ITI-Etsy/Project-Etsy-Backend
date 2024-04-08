using Microsoft.AspNetCore.Mvc;

namespace Esty_Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
