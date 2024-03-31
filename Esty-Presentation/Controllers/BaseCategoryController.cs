using Esty_Applications.Services.BaseCategory;
using Etsy_DTO.BaseCategory;
using Microsoft.AspNetCore.Mvc;

namespace Esty_Presentation.Controllers
{
    public class BaseCategoryController : Controller
    {
        private readonly IBaseCategoryServices _baseCategoryServices;

        public BaseCategoryController(IBaseCategoryServices baseCategoryServices)
        {
            _baseCategoryServices = baseCategoryServices;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _baseCategoryServices.GetAllBaseCategory();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReturnAddUpdateBaseCategoryDTO baseCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _baseCategoryServices.CreateBaseCategory(baseCategoryDTO);
                    return RedirectToAction(nameof(Index));
            }
            return View(baseCategoryDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _baseCategoryServices.GetBaseCategoryById(id);
            return View(result.Entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReturnAddUpdateBaseCategoryDTO baseCategoryDTO)
        {

            if (ModelState.IsValid)
            {
                var result = await _baseCategoryServices.UpdateBaseCategory(baseCategoryDTO);
                if (result.Entity != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(baseCategoryDTO);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _baseCategoryServices.DeleteBaseCategory(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
