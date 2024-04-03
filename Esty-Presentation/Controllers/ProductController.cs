using Esty_Applications.Services.Product;
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

        
        public async Task<IActionResult> Index(int pageNumber = 1, int itemsPerPage = 5)
        {
            var products = await _productsServices.GetAllProducts(itemsPerPage, pageNumber);
            ViewBag.TotalItemCount = products.Count;
            return View(products);
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

        //Cheek this in services didnt work correctly
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

        // i want this service to be  Delete(int ProdutcId)
        //Abanoub: Solve this Problem 
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productsServices.DeleteProduct(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
