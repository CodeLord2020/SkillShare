using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Data;

namespace SkillShare.Persistence.Repositories
{
    public class ReputationRepository : IReputationRepository
    {
        private readonly AppDbContext _context;

        public ReputationRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Reputation>> GetAllReputationsAsync()
        {
            return await _context.Reputations.ToListAsync();
        }

        public async Task<Reputation> GetReputationByIdAsync(Guid id)
        {
            return await _context.Reputations.FindAsync(id);
        }

        public async Task<Reputation> GetReputationByUserIdAsync(Guid userId)
        {
            return await _context.Reputations
                .SingleOrDefaultAsync(r => r.UserId == userId);
        }

        public async Task AddReputationAsync(Reputation reputation)
        {
            await _context.Reputations.AddAsync(reputation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReputationAsync(Reputation reputation)
        {
            _context.Reputations.Update(reputation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReputationAsync(Guid id)
        {
            var reputation = await _context.Reputations.FindAsync(id);
            if (reputation != null)
            {
                _context.Reputations.Remove(reputation);
                await _context.SaveChangesAsync();
            }
        }
    }
}