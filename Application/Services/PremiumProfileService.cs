using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Services
{
    public class PremiumProfileService : IPremiumProfileService
    {
        private readonly IPremiumProfileRepository _premiumProfileRepository;

        public PremiumProfileService(IPremiumProfileRepository premiumProfileRepository)
        {
            _premiumProfileRepository = premiumProfileRepository;
        }
        public async Task AddPremiumProfileAsync(PremiumProfile premiumProfile)
        {
            await _premiumProfileRepository.AddPremiumProfileAsync(premiumProfile);
        }

        public async Task<IEnumerable<PremiumProfile>> GetAllPremiumProfilesAsync()
        {
            return await _premiumProfileRepository.GetAllPremiumProfilesAsync();
        }

        public async Task<PremiumProfile> GetPremiumProfileByIdAsync(Guid id)
        {
            return await _premiumProfileRepository.GetPremiumProfileByIdAsync(id);
        }

        public async Task<PremiumProfile> GetPremiumProfileByUserIdAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new InvalidOperationException("Invalid user ID");
            }
            return await _premiumProfileRepository.GetPremiumProfileByUserIdAsync(userId);
        }

        public async Task UpdatePremiumProfileAsync(PremiumProfile premiumProfile)
        {

            if (premiumProfile == null)
            {
                throw new InvalidOperationException("Profile not found");
            }
            await _premiumProfileRepository.UpdatePremiumProfileAsync(premiumProfile);
        
        }

        public async Task DeletePremiumProfileAsync(Guid id)
        {
            await _premiumProfileRepository.DeletePremiumProfileAsync(id);
        }
    }
}