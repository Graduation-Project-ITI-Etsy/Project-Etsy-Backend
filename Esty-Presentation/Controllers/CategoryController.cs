using Esty_Applications.Services.Category;
using Etsy_DTO.Category;
using Microsoft.AspNetCore.Mvc;

namespace Esty_Presentation.Controllers
{
    public class CategoryController : Controller
    {
            private readonly ICategoryServices _categoryServices;

            public CategoryController(ICategoryServices categoryServices)
            {
                _categoryServices = categoryServices;
            }

            public async Task<IActionResult> Index()
            {
                var result = await _categoryServices.GetAllCategory();
                return View(result);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(ReturnAddUpdateCategoryDTO category)
            {
                if (ModelState.IsValid)
                {
                    var result = await _categoryServices.CreateCategory(category);
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }

            public async Task<IActionResult> Edit(int id)
            {
                var category = await _categoryServices.GetCategoryById(id);
                if (category.Entity == null)
                {
                    return NotFound();
                }
                return View(category.Entity);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(ReturnAddUpdateCategoryDTO category)
            {

                if (ModelState.IsValid)
                {
                    var result = await _categoryServices.UpdateCategory(category);
                    TempData["Message"] = result.Message;

                return RedirectToAction(nameof(Index));
                }
                return View(category);
            }

            public async Task<IActionResult> Details(int id)
            {
                var category = await _categoryServices.GetCategoryById(id);
                if (category.Entity == null)
                {
                    return NotFound();
                }
                return View(category.Entity);
            }

       
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryServices.DeleteCategory(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

    }
}
