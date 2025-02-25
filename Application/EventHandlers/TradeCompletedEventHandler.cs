
using MediatR;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Events;

namespace SkillShare.Application.EventHandlers
{
    public class TradeCompletedEventHandler : INotificationHandler<TradeCompletedEvent>
    {
        private readonly IReputationService _reputationService;
        public TradeCompletedEventHandler (IReputationService reputationService)
        {
            _reputationService = reputationService;
        }

        public async Task Handle(TradeCompletedEvent notification, CancellationToken  cancellationToken )
        {
            var trade = notification.Trade;

            var initiatorReputation = await _reputationService.GetReputationByUserIdAsync(trade.InitiatorId);
            if (initiatorReputation != null)
            {
                initiatorReputation.Score += 1; // Increment reputation score
                await _reputationService.UpdateReputationAsync(initiatorReputation);
            }

            var receiverReputation = await _reputationService.GetReputationByUserIdAsync(trade.ReceiverId);
            if (receiverReputation != null)
            {
                receiverReputation.Score += 1; // Increment reputation score
                await _reputationService.UpdateReputationAsync(receiverReputation);
            }
        }
    }
}