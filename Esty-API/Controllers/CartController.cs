using Esty_Applications.Services.Carts;
using Esty_Applications.Services.Product;
using Etsy_DTO.Carts;
using Etsy_DTO.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices CartServices;

        public CartController(ICartServices cartServices)
        {
            CartServices = cartServices;
        }

        [HttpPost]
        public async Task<IActionResult> CartCreate([FromBody] ReturnAddUpdateCartDTO CartDTO)
        {
            try
            {
                var result = await CartServices.CreateCart(CartDTO);

                if (result.Entity != null)
                {
                    return CreatedAtAction(nameof(CartDTO), new { id = result.Entity.CartID }, result.Entity);
                }
                else
                {
                    return BadRequest(result.Message ?? "Failed to create Cart.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetCards(string CustomerId)
        {
            try
            {
                var QueryCards = await CartServices.GetAllCards(CustomerId);
                if (QueryCards == null)
                {
                    return NotFound();
                }
                return Ok(QueryCards);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
