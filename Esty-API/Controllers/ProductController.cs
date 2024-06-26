﻿using Esty_Applications.Services.Product;
using Etsy_DTO.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
                var QueryProduct = await productsServices.SearchByProductID(id);
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
                var QueryProduct = await productsServices.SearchByProductName(productName);
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

        [HttpPost()]
        public async Task<IActionResult> EditProduct([FromBody] ProductStockNumDTO productDTO)
        {
            try
            {
                var QueryProduct = await productsServices.UpdateProductStock(productDTO);
                if (QueryProduct.Entity != null)
                {
                    return Ok(QueryProduct);
                }
                else
                {
                    return BadRequest("Failed to Edit the Product.");
                }
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

        [HttpGet("FilterProduct/{id}/{items},{page}")]
        public async Task<IActionResult> GetProductsByCatetgoryId(int id, int items, int page)
        {
            try
            {
                var QueryAllProducts = await productsServices.GetProductsByCategoryId(id, items, page);
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

        [HttpGet("PriceAscending/{id}/{items},{page}")]
        public async Task<IActionResult> GetProductPriceAscending(int id, int items, int page)
        {
            try
            {
                var QueryAllProducts = await productsServices.FilterPriceAscending(id, items, page);
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

        [HttpGet("PriceDescending/{id}/{items},{page}")]
        public async Task<IActionResult> GetProductPriceDescending(int id, int items, int page)
        {
            try
            {
                var QueryAllProducts = await productsServices.FilterPriceDescending(id, items, page);
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

        [HttpGet("Reviews/{id}/{items},{page}")]
        public async Task<IActionResult> GetProductCustomerReview(int id, int items, int page)
        {
            try
            {
                var QueryAllProducts = await productsServices.FilterProductsCustomerReview(id, items, page);
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
