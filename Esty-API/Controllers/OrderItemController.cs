using Esty_Applications.Services.Order;
using Esty_Applications.Services.OrderItems;
using Etsy_DTO.OrderItem;
using Etsy_DTO.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {

        private readonly IOrderItemsServices _orderItemsServices;
        public OrderItemController(IOrderItemsServices orderItemsServices)
        {
            _orderItemsServices = orderItemsServices;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrderItem([FromBody] ReturnAddUpdateOrderItemsDTO orderItemDTO)
        {
            try
            {
                var result =await _orderItemsServices.AddOrderItem(orderItemDTO);

                if (result.Entity != null)
                {
                    return CreatedAtAction(nameof(CreateOrderItem), new { id = result.Entity.OrderItemId }, result.Entity);
                }
                else
                {
                    return BadRequest(result.Message ?? "Failed to add the order item.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            try
            {
                var result =await _orderItemsServices.DeleteOrderItem(id);
                if (result.Message == "Order item deleted successfully")
                {
                    return NoContent();

                }
                else
                {
                    return NotFound(result.Message ?? "Order item Not found.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing the request: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }



    }
}
