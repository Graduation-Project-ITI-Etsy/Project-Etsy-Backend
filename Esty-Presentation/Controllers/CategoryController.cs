using Esty_Applications.Services.BaseCategory;
using Esty_Applications.Services.BaseCategoryServices;
using Esty_Applications.Services.Category;
using Esty_Models;
using Etsy_DTO.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Esty_Presentation.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IBaseCategoryServices _baseCategoryServices;
        private readonly IStringLocalizer<CategoryController> _localizer;

        public CategoryController(ICategoryServices categoryServices ,IBaseCategoryServices baseCategoryServices, IStringLocalizer<CategoryController> localizer)
        {
            _categoryServices = categoryServices;
            _baseCategoryServices = baseCategoryServices;
            _localizer = localizer;

        }

        public async Task<IActionResult> Index(int BaseCategoryId,int pageNumber = 1, int itemsPerPage = 5)
            {
            ViewBag.Categories = _localizer[name: "Categories"];
            ViewBag.Createe = _localizer[name: "Createe"];
            ViewBag.basec = _localizer[name: "basec"];
            ViewBag.Appplly = _localizer[name: "Appplly"];
            ViewBag.NameENN = _localizer[name: "NameENN"];
            ViewBag.NameARR = _localizer[name: "NameARR"];
            ViewBag.Imagee = _localizer[name: "Imagee"];
            ViewBag.AActions = _localizer[name: "AActions"];
            ViewBag.Detaillss = _localizer[name: "Detaillss"];
            ViewBag.EEdit = _localizer[name: "EEdit"];
            ViewBag.DDelete = _localizer[name: "DDelete"];
            ViewBag.Firstt = _localizer[name: "Firstt"];
            ViewBag.Lastt = _localizer[name: "Lastt"];



            var result = await _categoryServices.GetAllCategorypag(itemsPerPage, pageNumber);

            if (BaseCategoryId !=0)
            {    
                result = await _categoryServices.GetCategoriesByBaseCategoryId(BaseCategoryId);
            }
            var basecategoriesResult = await _baseCategoryServices.GetAllBaseCategory();
            ViewBag.baseCategories = basecategoriesResult.Entities;
            ViewBag.TotalItemCount = result.Count;

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
