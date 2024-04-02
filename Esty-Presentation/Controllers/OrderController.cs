using Esty_Applications.Services.Order;
using Etsy_DTO.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Esty_Presentation.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async Task<IActionResult> Index()
        {
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
