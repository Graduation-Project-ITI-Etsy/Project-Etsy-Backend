using Esty_Applications.Services.Order;
using Esty_Applications.Services.OrderItems;
using Etsy_DTO.OrderItem;
using Etsy_DTO.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult CreateOrderItem([FromBody] ReturnAddUpdateOrderItemsDTO orderDTO)
        {
            try
            {
                var result = _orderItemsServices.AddOrderItem(orderDTO);

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

        [HttpDelete]
        public IActionResult DeleteOrderItem([FromBody] ReturnAddUpdateOrderItemsDTO orderDTO)
        {
            try
            {
                var result = _orderItemsServices.DeleteOrderItem(orderDTO);
                if (result.Message == "Order deleted successfully")
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(result.Message ?? "Order item not found.");
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
