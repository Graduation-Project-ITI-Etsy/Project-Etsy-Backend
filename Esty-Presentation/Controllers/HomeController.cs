using Esty_Applications.Services.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Esty_Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IOrderServices _orderServices;
  

        public HomeController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
  

        }
        public async Task<IActionResult> Index()
        {
            var orderStatusCounts = await _orderServices.GetOrderStatusCounts();
            return View(orderStatusCounts);
        }
    }
}
