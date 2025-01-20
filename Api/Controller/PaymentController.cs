using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.PaymentContainer;
using DataAccess.Dtos.PaymentDto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentDto createPaymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payment = await _paymentService.CreatePayment(createPaymentDto);
            return Ok(payment);
        }
    }
}