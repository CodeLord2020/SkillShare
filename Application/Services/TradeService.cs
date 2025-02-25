using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;
using SkillShare.Domain.Enums;
using SkillShare.Domain.Events;

namespace SkillShare.Application.Services
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly IMediator _mediator;

        public TradeService(ITradeRepository tradeRepository, IMediator mediator)
        {
            _tradeRepository = tradeRepository ?? throw new ArgumentNullException(nameof(tradeRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
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
            // Raise TradeCompletedEvent if the trade is marked as completed
            if (trade.Status == TradeStatus.Completed)
            {
                await _mediator.Publish(new TradeCompletedEvent(trade));
            }
        }

        public async Task DeleteTradeAsync(Guid id)
        {
            await _tradeRepository.DeleteTradeAsync(id);
        }
    }
}