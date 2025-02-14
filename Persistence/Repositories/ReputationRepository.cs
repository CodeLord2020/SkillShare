using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Data;

namespace SkillShare.Persistence.Repositories
{
    public class ReputationRepository : IReputationRepository
    {
        private readonly AppDbContext _appDbContext;

        public ReputationRepository(AppDbContext context)
        {
            _appDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Reputation>> GetAllReputationsAsync()
        {
            return await _appDbContext.Reputations.ToListAsync();
        }

        public async Task<Reputation> GetReputationByIdAsync(Guid id)
        {
            var reputation =  await _appDbContext.Reputations.FindAsync(id);
            return reputation ?? throw new Exception($"Reputation with id: {id} not found.");
        }

        public async Task<Reputation> GetReputationByUserIdAsync(Guid userId)
        {
            var userRep = await _appDbContext.Reputations
                .SingleOrDefaultAsync(r => r.UserId == userId);
            return userRep ?? throw new Exception($"Reputation for user with userId: {userId} not found.");
        }

        public async Task AddReputationAsync(Reputation reputation)
        {
            await _appDbContext.Reputations.AddAsync(reputation);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateReputationAsync(Reputation reputation)
        {
            _appDbContext.Reputations.Update(reputation);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteReputationAsync(Guid id)
        {
            var reputation = await _appDbContext.Reputations.FindAsync(id);
            if (reputation != null)
            {
                _appDbContext.Reputations.Remove(reputation);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}