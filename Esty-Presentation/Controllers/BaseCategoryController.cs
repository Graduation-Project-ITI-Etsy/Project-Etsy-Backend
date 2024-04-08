using Esty_Applications.Services.BaseCategory;
using Esty_Presentation.Models;
using Etsy_DTO.BaseCategory;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace Esty_Presentation.Controllers
{
    public class BaseCategoryController : Controller
    {
        private readonly IBaseCategoryServices _baseCategoryServices;
        private readonly IStringLocalizer<BaseCategoryController> _localizer;
        public BaseCategoryController(IBaseCategoryServices baseCategoryServices, IStringLocalizer<BaseCategoryController> localizer)
        {
            _baseCategoryServices = baseCategoryServices;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index( int pageNumber = 1, int itemsPerPage = 5)
        {
            ViewBag.Zyad = _localizer[name: "zyad"];
            ViewBag.Create = _localizer[name: "Create"];
            ViewBag.NameEN = _localizer[name: "NameEN"];
            ViewBag.NameAR = _localizer[name: "NameAR"];
            ViewBag.Image = _localizer[name: "Image"];
            ViewBag.Actions = _localizer[name: "Actions"];
            ViewBag.Edit = _localizer[name: "Edit"];
            ViewBag.Delete = _localizer[name: "Delete"];



            var result = await _baseCategoryServices.GetAllBaseCategorypag(pageNumber, itemsPerPage);
            ViewBag.TotalItemCount = result.Count;
            return View(result);
        }


        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
