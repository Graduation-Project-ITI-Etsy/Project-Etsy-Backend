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
        private readonly IStringLocalizer<HomeController> _localizer;


        public HomeController(IOrderServices orderServices
            ,IProductsServices productsServices
            ,IBaseCategoryServices baseCategoryServices
            ,ICategoryServices categoryServices
            ,IPaymentServices paymentServices
            , IStringLocalizer<HomeController> localizer)
        {
            _orderServices = orderServices;
            _baseCategoryServices = baseCategoryServices;
            _productsServices = productsServices;
            _categoryServices = categoryServices;
            _paymentServices = paymentServices;
            _localizer = localizer;

        }
        public async Task<IActionResult> Index()
        {
            //Localization
            ViewBag.countBC = _localizer[name: "countBC"];
            ViewBag.countC = _localizer[name: "countC"];
            ViewBag.CountP = _localizer[name: "countP"];
            ViewBag.countO = _localizer[name: "countO"];
            ViewBag.countPay = _localizer[name: "countPay"];
            ViewBag.countPayP = _localizer[name: "countPayP"];
            ViewBag.countCP = _localizer[name: "countCP"];
            ViewBag.countOD = _localizer[name: "countOD"];
            ViewBag.countOrderS = _localizer[name: "countOrderS"];



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
