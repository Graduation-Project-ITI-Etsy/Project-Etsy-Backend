using Esty_Applications.Services.Order;
using Etsy_DTO.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Esty_Presentation.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly IStringLocalizer<OrderController> _localizer;

        public OrderController(IOrderServices orderServices, IStringLocalizer<OrderController> localizer)
        {
            _orderServices = orderServices;
            _localizer = localizer;

        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Orders = _localizer[name: "Orders"];
            ViewBag.Address = _localizer[name: "Address"];
            ViewBag.TotalPrice = _localizer[name: "TotalPrice"];
            ViewBag.Actionss = _localizer[name: "Actionss"];
            ViewBag.Details = _localizer[name: "Details"];
            ViewBag.Editt = _localizer[name: "Edit"];
            ViewBag.Deletee = _localizer[name: "Delete"];




            var result = await _orderServices.GetAllOrders();
            return View(result);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var Order = await _orderServices.GetByOrderByID(id);

            return View(Order.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReturnAddUpdateOrderDTO Order)
        {

            if (ModelState.IsValid)
            {
                var result = await _orderServices.UpdateOrder(Order);
                TempData["Message"] = result.Message;

                return RedirectToAction(nameof(Index));
            }
            return View(Order);
        }

        public async Task<IActionResult> Details(int id)
        {
            var Order = await _orderServices.GetByOrderByID(id);
            if (Order.Entity == null)
            {
                return NotFound();
            }
            return View(Order.Entity);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderServices.DeleteOrder(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

    }
}
