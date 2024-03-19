﻿using Esty_Applications.Services.Category;
using Etsy_DTO.Category;
using Etsy_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        [Route("Get")]
        public ReturnResultHasObjsDTO<ReturnAllCategoryDTO> GetAllCategories()
        {
            return _categoryServices.GetAllCategory();
        }

        [HttpGet]
        [Route("SearchCategory")]
        public IActionResult SearchCategoryByName(string name)
        {
            try
            {
                var category = _categoryServices.SearchCategoryByName(name);
                if (category == null)
                {
                    return NotFound("Category not found");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(503, "An error occurred while processing your request.");
            }
        }
    }
}