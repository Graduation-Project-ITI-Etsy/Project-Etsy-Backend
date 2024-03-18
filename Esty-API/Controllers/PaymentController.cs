
using Microsoft.AspNetCore.Mvc;
using Esty_Applications.Services.Payment;
using Etsy_DTO.Payment;

using System;
using Etsy_DTO.Orders;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentService;

        public PaymentController(IPaymentServices paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreatePayment([FromBody] ReturnAddUpdatePaymentDTO paymentDto)
        {
            try
            {
                var result = _paymentService.CreatePayment(paymentDto);

                if (result.Entity != null)
                {
                    return CreatedAtRoute(nameof(GetPaymentByID), new { paymentId = result.Entity.PaymentID }, result.Entity);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet]
        [Route("{paymentId}", Name = nameof(GetPaymentByID))]
        public IActionResult GetPaymentByID(int paymentId)
        {
            try
            {
                var result = _paymentService.SearchByPaymentByID(paymentId);
                if (result.Entity != null)
                {
                    return Ok(result.Entity);
                }
                else
                {
                    return NotFound("Payment not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        }
}
