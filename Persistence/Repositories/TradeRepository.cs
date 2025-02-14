using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Data;

namespace SkillShare.Persistence.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly AppDbContext _appDbContext;
        public TradeRepository(AppDbContext appdbContext)
        {
            _appDbContext = appdbContext ?? throw new ArgumentNullException(nameof(appdbContext));
        }

        public async Task<IEnumerable<Trade>> GetAllTradesAsync()
        {
            return await _appDbContext.Trades.ToListAsync();
        }

        public async Task<Trade> GetTradeByIdAsync(Guid id)
        {
             var trade = await _appDbContext.Trades.FindAsync(id);
             return trade ?? throw new Exception($"Trade with id: {id} not found.");
        }

        public async Task<IEnumerable<Trade>> GetTradesByUserIdAsync(Guid userId)
        {
            return await _appDbContext.Trades
                .Where(t => t.InitiatorId == userId || t.ReceiverId == userId)
                .ToListAsync();
        }

        public async Task AddTradeAsync(Trade trade)
        {
            await _appDbContext.Trades.AddAsync(trade);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateTradeAsync(Trade trade)
        {
            _appDbContext.Trades.Update(trade);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteTradeAsync(Guid id)
        {
            var trade = await _appDbContext.Trades.FindAsync(id);
            if (trade != null)
            {
                _appDbContext.Trades.Remove(trade);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}