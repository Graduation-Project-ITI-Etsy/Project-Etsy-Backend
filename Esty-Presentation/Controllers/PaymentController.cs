using Microsoft.AspNetCore.Mvc;
using Esty_Applications.Services.Payment;
using Etsy_DTO.Payment;
using Esty_Models;
using Microsoft.Extensions.Localization;
namespace Esty_Presentation.Controllers
{
    

    namespace admin.Controllers
    {
        public class PaymentController : Controller
        {
            private readonly IPaymentServices _paymentServices;
            private readonly IStringLocalizer<PaymentController> _localizer;

            public PaymentController(IPaymentServices paymentServices, IStringLocalizer<PaymentController> localizer)
            {
                _paymentServices = paymentServices;
                _localizer = localizer;

            }

            public async Task<IActionResult> Index()
            {
                ViewBag.Payments = _localizer[name: "Payments"];
                ViewBag.ID = _localizer[name: "ID"];
                ViewBag.Price = _localizer[name: "Price"];
                ViewBag.Response = _localizer[name: "Response"];
                ViewBag.Actionsss = _localizer[name: "Actionsss"];
                ViewBag.Edittt = _localizer[name: "Edittt"];
                ViewBag.Delette = _localizer[name: "Delette"];




                var allPayments = await _paymentServices.GetAllPayment();
                return View(allPayments);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(ReturnAddUpdatePaymentDTO paymentDto)
            {
                if (ModelState.IsValid)
                {
                    var result = await _paymentServices.CreatePayment(paymentDto);
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                return View(paymentDto);
            }

            public async Task<IActionResult> Edit(int id)
            {
                var paymentDto = await _paymentServices.SearchByPaymentByID(id);
                if (paymentDto.Entity == null)
                {
                    return NotFound();
                }
                return View(paymentDto.Entity);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(ReturnAddUpdatePaymentDTO paymentDto)
            {
                if (ModelState.IsValid)
                {
                    var result = await _paymentServices.UpdatePayment(paymentDto);
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                return View(paymentDto);
            }

            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _paymentServices.DeletePayment(id);
                TempData["Message"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }

}
