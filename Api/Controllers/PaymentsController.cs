using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.Interfaces;

namespace SkillShare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest request)
        {
            var sessionId = await _paymentService.CreateCheckoutSessionAsync(request.Amount, request.Currency, request.SuccessUrl, request.CancelUrl);
            return Ok(new { SessionId = sessionId });
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentRequest request)
        {
            var success = await _paymentService.ProcessPaymentAsync(request.PaymentIntentId);
            return Ok(new { Success = success });
        }

        public class CreateCheckoutSessionRequest
        {
            public decimal Amount { get; set; }
            public string Currency { get; set; } = "usd";
            public required string SuccessUrl { get; set; }
            public required string CancelUrl { get; set; }
        }

        public class ProcessPaymentRequest
        {
            public required string PaymentIntentId { get; set; }
        }


    }
}