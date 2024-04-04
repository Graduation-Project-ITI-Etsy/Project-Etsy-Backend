using Esty_Applications.Services.Product;
using Esty_Models;
using Etsy_DTO;
using Etsy_DTO.Products;
using Microsoft.AspNetCore.Mvc;

namespace Esty_Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsServices _productsServices;

        public ProductController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }


        public async Task<IActionResult> Index(string searchTerm,int categoryId=1, int filtrationMethod = 0, int pageNumber = 1, int itemsPerPage = 5)
        {
            ReturnResultHasObjsDTO<ReturnAllProductsDTO> products;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = await _productsServices.SearchProducts(searchTerm, itemsPerPage, pageNumber);
            }
            else
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
                        products = await _productsServices.GetAllProducts(itemsPerPage, pageNumber);
                        break;
                }
            }

            ViewBag.TotalItemCount = products.Count;
            ViewBag.SearchTerm = searchTerm;
            ViewBag.filtrationMethod = filtrationMethod;


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
