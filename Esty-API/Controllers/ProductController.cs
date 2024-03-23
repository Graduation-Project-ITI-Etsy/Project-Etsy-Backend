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
        public async Task<IActionResult> GetAllProduct(int items, int page)
        {
            try
            {
                var QueryAllProducts = await productsServices.GetAllProducts(items, page);
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
        public async Task<IActionResult> GetProductByID(int id)
        {
            try
            {
                var QueryProduct =await productsServices.SearchByProductID(id);
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
        public async Task<IActionResult> GetProductByName(string productName)
        {
            try
            {
                var QueryProduct =await productsServices.SearchByProductName(productName);
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
        public async Task<IActionResult> FilterProductByPrice(int MinPrice, int MaxPrice, int CategoryId)
        {
            try
            {
                var QueryAllProducts = await productsServices.FilterProductByPrice(MinPrice, MaxPrice, CategoryId);
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

        [HttpGet("FilterProduct/{id:int}")]
        public async Task<IActionResult> GetProductsByCatetgoryId(int id)
        {
            try
            {
                var QueryAllProducts = await productsServices.GetProductsByCategoryId(id);
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
