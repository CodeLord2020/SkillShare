using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository ?? throw new ArgumentNullException(nameof(tradeRepository));
        }

        public async Task<IEnumerable<Trade>> GetAllTradesAsync()
        {
            return await _tradeRepository.GetAllTradesAsync();
        }

        public async Task<Trade> GetTradeByIdAsync(Guid id)
        {
            return await _tradeRepository.GetTradeByIdAsync(id);
        }

        public async Task<IEnumerable<Trade>> GetTradesByUserIdAsync(Guid userId)
        {
            return await _tradeRepository.GetTradesByUserIdAsync(userId);
        }

        public async Task AddTradeAsync(Trade trade)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            await _tradeRepository.AddTradeAsync(trade);
        }

        public async Task UpdateTradeAsync(Trade trade)
        {
            if (trade == null)
            {
                throw new ArgumentNullException(nameof(trade));
            }

            await _tradeRepository.UpdateTradeAsync(trade);
        }

        public async Task DeleteTradeAsync(Guid id)
        {
            await _tradeRepository.DeleteTradeAsync(id);
        }
    }
}