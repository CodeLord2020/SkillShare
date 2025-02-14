using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Data;

namespace SkillShare.Persistence.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly AppDbContext _context;

        public TradeRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Trade>> GetAllTradesAsync()
        {
            return await _context.Trades.ToListAsync();
        }

        public async Task<Trade> GetTradeByIdAsync(Guid id)
        {
            return await _context.Trades.FindAsync(id);
        }

        public async Task<IEnumerable<Trade>> GetTradesByUserIdAsync(Guid userId)
        {
            return await _context.Trades
                .Where(t => t.InitiatorId == userId || t.ReceiverId == userId)
                .ToListAsync();
        }

        public async Task AddTradeAsync(Trade trade)
        {
            await _context.Trades.AddAsync(trade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTradeAsync(Trade trade)
        {
            _context.Trades.Update(trade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTradeAsync(Guid id)
        {
            var trade = await _context.Trades.FindAsync(id);
            if (trade != null)
            {
                _context.Trades.Remove(trade);
                await _context.SaveChangesAsync();
            }
        }
    }
}