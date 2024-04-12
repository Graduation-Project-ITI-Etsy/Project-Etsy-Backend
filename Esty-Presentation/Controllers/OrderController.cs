using Esty_Applications.Services.Order;
using Etsy_DTO.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


namespace Esty_Presentation.Controllers
{
    [Authorize]
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
            ViewBag.Status = _localizer[name: "Status"];
            ViewBag.Actionss = _localizer[name: "Actionss"];
            ViewBag.Details = _localizer[name: "Details"];
            ViewBag.Editt = _localizer[name: "Editt"];
            ViewBag.Deletee = _localizer[name: "Deletee"];




            var result = await _orderServices.GetAllOrders();
            return View(result);
        }


        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.EditOr = _localizer[name: "EditOr"];
            ViewBag.StatusOr = _localizer[name: "StatusOr"];
            ViewBag.Placed = _localizer[name: "Placed"];
            ViewBag.Confirm = _localizer[name: "Confirm"];
            ViewBag.Shipped = _localizer[name: "Shipped"];
            ViewBag.Delivered = _localizer[name: "Delivered"];
            ViewBag.Canceled = _localizer[name: "Canceled"];
            ViewBag.Return = _localizer[name: "Return"];
            ViewBag.UpdateOr = _localizer[name: "UpdateOr"];
            ViewBag.BtLOr = _localizer[name: "BtLOr"];

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
            ViewBag.OrDetails = _localizer[name: "OrDetails"];
            ViewBag.OrID = _localizer[name: "OrID"];
            ViewBag.PAddress = _localizer[name: "PAddress"];
            ViewBag.PTPrice = _localizer[name: "PTPrice"];
            ViewBag.ArrivedOn = _localizer[name: "ArrivedOn"];
            ViewBag.Stattus = _localizer[name: "Stattus"];
            ViewBag.CId = _localizer[name: "CId"];
            ViewBag.DEdit = _localizer[name: "DEdit"];
            ViewBag.BtlOD = _localizer[name: "BtlOD"];


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
