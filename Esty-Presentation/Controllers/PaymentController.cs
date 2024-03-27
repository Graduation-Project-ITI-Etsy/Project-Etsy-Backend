using Microsoft.AspNetCore.Mvc;
using Esty_Applications.Services.Payment;
using Etsy_DTO.Payment;
namespace Esty_Presentation.Controllers
{
    

    namespace admin.Controllers
    {
        public class PaymentController : Controller
        {
            private readonly IPaymentServices _paymentServices;

            public PaymentController(IPaymentServices paymentServices)
            {
                _paymentServices = paymentServices;
            }

            public async Task<IActionResult> Index()
            {
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
