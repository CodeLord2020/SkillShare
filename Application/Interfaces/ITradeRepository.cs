using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Interfaces
{
    public interface ITradeRepository
    {
         Task<IEnumerable<Trade>> GetAllTradesAsync();
        Task<Trade> GetTradeByIdAsync(Guid id);
        Task<IEnumerable<Trade>> GetTradesByUserIdAsync(Guid userId);
        Task AddTradeAsync(Trade trade);
        Task UpdateTradeAsync(Trade trade);
        Task DeleteTradeAsync(Guid id);
    }
}