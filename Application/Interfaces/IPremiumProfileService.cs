using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Interfaces
{
    public interface IPremiumProfileService
    {
        Task<IEnumerable<PremiumProfile>> GetAllPremiumProfilesAsync();
        Task<PremiumProfile> GetPremiumProfileByIdAsync(Guid id);
        Task<PremiumProfile> GetPremiumProfileByUserIdAsync(Guid userId);
        Task AddPremiumProfileAsync(PremiumProfile premiumProfile);
        Task UpdatePremiumProfileAsync(PremiumProfile premiumProfile);
        Task DeletePremiumProfileAsync(Guid id);

        
    }
}