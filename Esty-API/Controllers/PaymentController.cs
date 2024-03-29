﻿
using Microsoft.AspNetCore.Mvc;
using Esty_Applications.Services.Payment;
using Etsy_DTO.Payment;

using System;
using Etsy_DTO.Orders;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> CreatePayment([FromBody] ReturnAddUpdatePaymentDTO paymentDto)
        {
            try
            {
                var result = await _paymentService.CreatePayment(paymentDto);

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
        public async Task<IActionResult> GetPaymentByID(int paymentId)
        {
            try
            {
                var result =await _paymentService.SearchByPaymentByID(paymentId);
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
