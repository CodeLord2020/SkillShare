using Stripe;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;
using System;
using System.Threading.Tasks;
using Stripe.Checkout;


namespace SkillShare.Application.Services
{
    public class StripePaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StripePaymentService> _logger;
        public StripePaymentService(IConfiguration configuration, ILogger<StripePaymentService> logger)
        {
            _logger = logger;
            _configuration = configuration;
            StripeConfiguration.ApiKey =  _configuration.GetSection("Stripe")["SecretKey"];
            
        }
        public async Task<string> CreateCheckoutSessionAsync(decimal amount, string currency, 
        string successUrl, string cancelUrl)
        {
            _logger.LogInformation("Creating checkout session for amount {Amount} {Currency}", amount, currency);
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(amount * 100), // Amount in cents
                            Currency = currency,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Premium Profile Subscription",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);
            _logger.LogInformation("Checkout session created with id {SessionId}", session.Id);

            return session.Id;
        }


        public async Task<bool> ProcessPaymentAsync(string paymentIntentId)
        {
            _logger.LogInformation("Processing payment for payment intent {PaymentIntentId}", paymentIntentId);
            var service = new PaymentIntentService();
            var paymentIntent = await service.GetAsync(paymentIntentId);

            _logger.LogInformation("Payment intent status is {Status}", paymentIntent.Status);
            return paymentIntent.Status == "succeeded";
        }
    }
}