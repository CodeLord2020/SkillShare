using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe;
using System.IO;
using System.Threading.Tasks;

namespace SkillShare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhooksController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WebhooksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("stripe")]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json, 
                    Request.Headers["Stripe-Signature"], 
                    _configuration.GetValue<string>("Stripe:SecretKey") // Ensure correct key retrieval
                );

                switch (stripeEvent.Type)
                {
                    case "payment_intent.succeeded":
                        var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                        // Handle successful payment
                        break;

                    case "payment_intent.payment_failed":
                        var failedPaymentIntent = stripeEvent.Data.Object as PaymentIntent;
                        // Handle failed payment
                        break;

                    default:
                        break;
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest($"Stripe webhook error: {e.Message}");
            }
        }
    }
}
