using Esty_Applications.Services.Order;
using Esty_Applications.Services.Payment;
using Esty_Models;
using Etsy_DTO.Orders;
using Etsy_DTO.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Esty_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderServices _orderService;
        private readonly UserManager<Customer> _userManager;

        public OrderController(IOrderServices orderServices, UserManager<Customer> userManager)
        {
            _orderService = orderServices;
            _userManager = userManager;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByID(int id)
        {
            try
            {
                var order = await _orderService.GetByOrderByID(id);

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
        public async Task<IActionResult> CreateOrder([FromBody] ReturnAddUpdateOrderDTO orderDTO)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Sid").Value;

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound(); // User not found in database
                }

                orderDTO.CustomerId = userId;

                var result =await _orderService.CreateOrder(orderDTO);

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
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] ReturnAddUpdateOrderDTO orderDTO)
        {
            try
            {

                var result = await _orderService.UpdateOrder(orderDTO);

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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {

                var result = await _orderService.DeleteOrder(id);
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

        [HttpGet("Orders/{customerId}")]
        public async Task<IActionResult> GetAllOrdersByCustomerId(string customerId)
        {
            try
            {
                var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Sid").Value;

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound(); // User not found in database
                }

                customerId = userId;
                var order = await _orderService.GetOrdersByCustomerId(customerId);

                if (order == null)
                {
                    return NotFound($"Orders not found.");
                }
                else
                {
					return Ok(new { Order = order, Status = "Success" });
				}

			}
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving order: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }
}

