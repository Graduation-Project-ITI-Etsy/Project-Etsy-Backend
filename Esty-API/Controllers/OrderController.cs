using Esty_Applications.Services.Order;
using Esty_Applications.Services.Payment;
using Etsy_DTO.Orders;
using Etsy_DTO.Payment;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderServices _orderService;
        public OrderController(IOrderServices orderServices)
        {
            _orderService = orderServices;
        }


        [HttpGet("{id}")]
        public IActionResult GetOrderByID(int id)
        {
            try
            {
                var order = _orderService.GetByOrderByID(id);

                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }

                return Ok(new { Order = order, Status = "Success" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving order with ID {id}: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] ReturnAddUpdateOrderDTO orderDTO )
        {
            try
            {
                var result = _orderService.CreateOrder(orderDTO);

                if (result.Entity != null )
                {
                    return CreatedAtAction(nameof(GetOrderByID), new { id = result.Entity.OrdersId }, result.Entity);
                }
                else
                {
                    return BadRequest(result.Message ?? "Failed to create the order.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        [HttpPut]
        public IActionResult UpdateOrder([FromBody] ReturnAddUpdateOrderDTO orderDTO)
        {
            try
            {
                var result = _orderService.UpdateOrder(orderDTO);

                if (result.Entity != null)
                {
                    return Ok(result.Entity);
                }
                else
                {
                    return NotFound(result.Message ?? "Order not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing the request: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        [HttpDelete]
        public IActionResult DeleteOrder([FromBody] ReturnAddUpdateOrderDTO orderDTO)
        {
            try
            {
                var result = _orderService.DeleteOrder(orderDTO);
                if (result.Message== "Order deleted successfully")
                {
                    return NoContent(); 
                }
                else
                {
                    return NotFound(result.Message ?? "Order not found.");
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

