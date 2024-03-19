using AutoMapper;
using Esty_Applications.Services.BaseCategory;
using Etsy_DTO.BaseCategory;
using Etsy_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCategoryController : ControllerBase
    {

        private readonly IBaseCategoryServices _BaseCategoryServices;
        private readonly IMapper _mapper;

        public BaseCategoryController(IBaseCategoryServices BaseCategoryServices, IMapper mapper)
        {
            _BaseCategoryServices = BaseCategoryServices;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]

        public ReturnResultHasObjsDTO<ReturnAllBaseCategoryDTO> GetAllBaseCategories()
        {
            return _BaseCategoryServices.GetAllBaseCategory();
        }


        [HttpGet]
        [Route("Search ")]
        public IActionResult SearchBaseCategoryByName(string name)
        {
            try
            {
                var category = _BaseCategoryServices.SearchBaseCategoryByName(name);
                if (category == null)
                {
                    return NotFound("BaseCategory not found");
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
