using Microsoft.AspNetCore.Mvc;

namespace Esty_Presentation.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
