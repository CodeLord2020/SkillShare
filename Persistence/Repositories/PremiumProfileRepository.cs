using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillShare.Application.Interfaces;

namespace SkillShare.Persistence.Repositories
{
    public class PremiumProfileRepository : IPremiumProfileRepository
    {
        private readonly AppDbContext _context;
        public PremiumProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PremiumProfile>> GetAllPremiumProfilesAsync()
        {
            return await _context.PremiumProfiles.ToListAsync();
        }

        public async Task<PremiumProfile> GetPremiumProfileByIdAsync(Guid id)
        {
            var profile = await _context.PremiumProfiles.FindAsync(id) ?? throw new InvalidOperationException($"No profile found for ID {id}");
            return profile;
        }

        public async Task<PremiumProfile> GetPremiumProfileByUserIdAsync(Guid userId)
        {
            var profile = await _context.PremiumProfiles
                .SingleOrDefaultAsync(p => p.UserId == userId);
            return profile == null ? throw new InvalidOperationException($"No profile found for user ID {userId}") : profile;
        }

        public async Task AddPremiumProfileAsync(PremiumProfile premiumProfile)
        {
            await _context.PremiumProfiles.AddAsync(premiumProfile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePremiumProfileAsync(PremiumProfile premiumProfile)
        {
            _context.PremiumProfiles.Update(premiumProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePremiumProfileAsync(Guid id)
        {
            var premiumProfile = await _context.PremiumProfiles.FindAsync(id);
            if (premiumProfile != null)
            {
                _context.PremiumProfiles.Remove(premiumProfile);
                await _context.SaveChangesAsync();
            }
        }
    }
}