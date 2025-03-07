using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Application.Interfaces;

namespace SkillShare.Application.Services
{
    public class StripePaymentService : IPaymentService
    {
        public Task<string> CraeteCheckoutSessionAsync(decimal amount, string currency, string suceessUrl, string cancelUrl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProcessPaymentAsync(string paymentIntentId)
        {
            throw new NotImplementedException();
        }
    }
}