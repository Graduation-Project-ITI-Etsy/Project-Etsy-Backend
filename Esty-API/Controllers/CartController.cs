using Esty_Applications.Services.Carts;
using Esty_Applications.Services.Product;
using Esty_Models;
using Etsy_DTO.Carts;
using Etsy_DTO.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartServices CartServices;
        private readonly UserManager<Customer> _userManager;

        public CartController(ICartServices cartServices , UserManager<Customer> userManager)
        {
            CartServices = cartServices;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CartCreate([FromBody] ReturnAddUpdateCartDTO CartDTO)
        {
            try
            {
                //var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Sid").Value;

                //var user = await _userManager.FindByIdAsync(userId);
                //if (user == null)
                //{
                //    return NotFound(); // User not found in database
                //}

                //CartDTO.CustomerId = userId;
                var result = await CartServices.CreateCart(CartDTO);

                if (result.Entity != null)
                {
                    return Ok(new { message = "Cart is Created" });
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
                //var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Sid").Value;

                //var user = await _userManager.FindByIdAsync(userId);
                //if (user == null)
                //{
                //    return NotFound(); // User not found in database
                //}

                //CustomerId = userId;

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

        [HttpDelete("Delete/{CustomerId}")]
        public async Task<IActionResult> DeleteCards(string CustomerId)
        {
            try
            {
                //var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Sid").Value;

                //var user = await _userManager.FindByIdAsync(userId);
                //if (user == null)
                //{
                //    return NotFound(); // User not found in database
                //}

                //CustomerId = userId;

                var QueryCards = await CartServices.DeleteCart(CustomerId);
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

        [HttpDelete("DeleteCartId/{CartId:int}")]
        public async Task<IActionResult> DeleteCardByCartId(int CartId)
        {
            try
            {

                var QueryCards = await CartServices.DeleteCartByCartId(CartId);
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


