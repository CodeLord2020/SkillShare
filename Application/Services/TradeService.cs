
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
        private readonly IEmailService _emailService;
        private readonly ILogger<TradeService> _logger;

        public TradeService(ITradeRepository tradeRepository, IMediator mediator,
         IEmailService emailService, ILogger<TradeService> logger)
        {
            _tradeRepository = tradeRepository ?? throw new ArgumentNullException(nameof(tradeRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                _logger.LogError("Trade is null");
                throw new ArgumentNullException(nameof(trade));
            }

            await _tradeRepository.AddTradeAsync(trade);
        }

        public async Task UpdateTradeAsync(Trade trade)
        {
            if (trade == null)
            {
                _logger.LogError("Trade is null");
                throw new ArgumentNullException(nameof(trade));
            }

            await _tradeRepository.UpdateTradeAsync(trade);
            _logger.LogInformation("Updating trade with id: {tradeId}", trade.Id);

            // Raise TradeCompletedEvent if the trade is marked as completed
            if (trade.Status == TradeStatus.Completed)
            {
                _logger.LogInformation("Trade with id: {tradeId} is completed", trade.Id);
                await _mediator.Publish(new TradeCompletedEvent(trade));
                var trade_initiator_Email = trade.Initiator.Email ?? throw new ArgumentNullException(nameof(trade.Initiator.Email));
                var trade_Receiver_Email = trade.Receiver.Email ?? throw new ArgumentNullException(nameof(trade.Receiver.Email));  

                var subject = "Trade Completed";
                var plainTextContent = $"Your trade with {trade.Receiver.Email} has been completed.";
                var htmlContent = $"<p>Your trade with {trade.Receiver.Email} has been completed.</p>";
                await _emailService.SendEmailAsync(trade_initiator_Email, subject, plainTextContent, htmlContent);
                await _emailService.SendEmailAsync(trade_Receiver_Email, subject, plainTextContent, htmlContent);
            }
        }

        public async Task DeleteTradeAsync(Guid id)
        {
            await _tradeRepository.DeleteTradeAsync(id);
        }
    }
}