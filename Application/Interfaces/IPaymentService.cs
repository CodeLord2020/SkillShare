using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillShare.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CraeteCheckoutSessionAsync(decimal amount, string currency,
         string suceessUrl, string cancelUrl);
         Task<bool> ProcessPaymentAsync(string paymentIntentId);
    }
}