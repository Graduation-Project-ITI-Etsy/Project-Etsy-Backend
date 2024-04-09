using Esty_Applications.Services.Category;
using Esty_Applications.Services.Product;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace Esty_Presentation.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductsServices _productsServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IStringLocalizer<ProductController> _localizer;


        public ProductController(IProductsServices productsServices, ICategoryServices categoryServices, IStringLocalizer<ProductController> localizer)
        {
            _productsServices = productsServices;
            _categoryServices = categoryServices;
            _localizer = localizer;
        }


        public async Task<IActionResult> Index(string searchTerm, int categoryId, int filtrationMethod = 0, int pageNumber = 1, int itemsPerPage = 5)
        {

            ViewBag.Products = _localizer[name: "Products"];
            ViewBag.CCreate = _localizer[name: "CCreate"];
            ViewBag.Search = _localizer[name: "Search"];
            ViewBag.AllC = _localizer[name: "AllC"];
            ViewBag.Select = _localizer[name: "Select"];
            ViewBag.Lprice = _localizer[name: "Lprice"];
            ViewBag.Hprice = _localizer[name: "Hprice"];
            ViewBag.Appply = _localizer[name: "Appply"];
            ViewBag.Name = _localizer[name: "Name"];
            ViewBag.IImage = _localizer[name: "IImage"];
            ViewBag.PPrice = _localizer[name: "PPrice"];
            ViewBag.Stock = _localizer[name: "Stock"];
            ViewBag.AAcctions = _localizer[name: "AAcctions"];
            ViewBag.EEditt = _localizer[name: "EEditt"];
            ViewBag.Detaills = _localizer[name: "Detaills"];
            ViewBag.DDeletee = _localizer[name: "DDeletee"];
            ViewBag.First = _localizer[name: "First"];
            ViewBag.Last = _localizer[name: "Last"];




            ReturnResultHasObjsDTO<ReturnAllProductsDTO> products;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = await _productsServices.SearchProducts(searchTerm, itemsPerPage, pageNumber);
            }
            else
            {
                if (categoryId != 0)
                {
                    switch (filtrationMethod)
                    {
                        case 1:
                            products = await _productsServices.FilterPriceAscending(categoryId, itemsPerPage, pageNumber);
                            break;
                        case 2:
                            products = await _productsServices.FilterPriceDescending(categoryId, itemsPerPage, pageNumber);
                            break;
                        default:
                            products = await _productsServices.GetProductsByCategoryId(categoryId, itemsPerPage, pageNumber);
                            break;
                    }
                }
                else { products = await _productsServices.SearchProducts(searchTerm, itemsPerPage, pageNumber); }
            }
            var categoriesResult = await _categoryServices.GetAllCategory();

       
                ViewBag.Categories = categoriesResult.Entities;
             
        


            ViewBag.TotalItemCount = products.Count;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.FiltrationMethod = filtrationMethod;

            return View(products);

        }


        public async Task<IActionResult> Search(string searchTerm)
        {
            return RedirectToAction(nameof(Index), new { searchTerm = searchTerm });
       }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReturnAddUpdateProductDTO product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productsServices.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productsServices.SearchByProductID(id);
            if (product.Entity == null)
            {
                return NotFound();
            }
            return View(product.Entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReturnAddUpdateProductDTO product)
        {
            if (ModelState.IsValid)
            {
                var result = await _productsServices.UpdateProduct(product);
                TempData["Message"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productsServices.SearchByProductID(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product.Entity);
        }

      
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productsServices.DeleteProduct(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
