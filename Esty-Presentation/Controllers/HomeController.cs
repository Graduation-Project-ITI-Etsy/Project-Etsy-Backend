using Esty_Applications.Services.BaseCategory;
using Esty_Applications.Services.BaseCategoryServices;
using Esty_Applications.Services.Category;
using Esty_Applications.Services.Order;
using Esty_Applications.Services.Payment;
using Esty_Applications.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Esty_Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IOrderServices _orderServices;
        private readonly IBaseCategoryServices _baseCategoryServices;
        private readonly IProductsServices _productsServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IPaymentServices _paymentServices;

        public HomeController(IOrderServices orderServices
            ,IProductsServices productsServices
            ,IBaseCategoryServices baseCategoryServices
            ,ICategoryServices categoryServices
            ,IPaymentServices paymentServices)
        {
            _orderServices = orderServices;
            _baseCategoryServices = baseCategoryServices;
            _productsServices = productsServices;
            _categoryServices = categoryServices;
            _paymentServices = paymentServices;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.BaseCategoryCount = await _baseCategoryServices.BaseCategoryCount();
            ViewBag.CategoryCount = await _categoryServices.CategoryCount();
            ViewBag.ProductCount = await _productsServices.ProductCount();
            ViewBag.OrdersCount = await _orderServices.OrderCount();
            ViewBag.Payments = await _paymentServices.PaymentsCount();
            ViewBag.CalculateProfit = await _paymentServices.CalculateProfit();
            ViewBag.CalculateTotalPricePaymects = await _paymentServices.CalculateTotalPricePaymects();
            var orderStatusCounts = await _orderServices.GetOrderStatusCounts();
            return View(orderStatusCounts);
        }
    }
}
