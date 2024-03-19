using Esty_Applications.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsServices productsServices;

        public ProductController(IProductsServices _productsServices)
        {
            productsServices = _productsServices;
        }

        [HttpGet("{items},{page}")]
        public IActionResult GetAllProduct(int items, int page)
        {
            try
            {
                var QueryAllProducts = productsServices.GetAllProducts(items, page);
                if (QueryAllProducts == null || QueryAllProducts.Count == 0)
                {
                    return NotFound("No Products Found !!");
                }
                return Ok(QueryAllProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductByID(int id)
        {
            try
            {
                var QueryProduct = productsServices.SearchByProductID(id);
                if (QueryProduct == null)
                {
                    return NotFound();
                }
                return Ok(QueryProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productName}")]
        public IActionResult GetProductByName(string productName)
        {
            try
            {
                var QueryProduct = productsServices.SearchByProductName(productName);
                if (QueryProduct == null)
                {
                    return NotFound();
                }
                return Ok(QueryProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Filter/{MinPrice:int},{MaxPrice:int},{CategoryId:int}")]
        public IActionResult FilterProductByPrice(int MinPrice, int MaxPrice, int CategoryId)
        {
            try
            {
                var QueryAllProducts = productsServices.FilterProductByPrice(MinPrice, MaxPrice, CategoryId);
                if (QueryAllProducts == null || QueryAllProducts.Count == 0)
                {
                    return NotFound("No Products Found !!");
                }
                return Ok(QueryAllProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
