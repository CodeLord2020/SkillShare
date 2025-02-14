using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Services
{
    public class ReputationService : IReputationService
    {
        private readonly IReputationRepository _reputationRepository;

        public ReputationService(IReputationRepository reputationRepository)
        {
            _reputationRepository = reputationRepository ?? throw new ArgumentNullException(nameof(reputationRepository));
        }

        public async Task<IEnumerable<Reputation>> GetAllReputationsAsync()
        {
            return await _reputationRepository.GetAllReputationsAsync();
        }

        public async Task<Reputation> GetReputationByIdAsync(Guid id)
        {
            return await _reputationRepository.GetReputationByIdAsync(id);
        }

        public async Task<Reputation> GetReputationByUserIdAsync(Guid userId)
        {
            return await _reputationRepository.GetReputationByUserIdAsync(userId);
        }

        public async Task AddReputationAsync(Reputation reputation)
        {
            if (reputation == null)
            {
                throw new ArgumentNullException(nameof(reputation));
            }

            await _reputationRepository.AddReputationAsync(reputation);
        }

        public async Task UpdateReputationAsync(Reputation reputation)
        {
            if (reputation == null)
            {
                throw new ArgumentNullException(nameof(reputation));
            }

            await _reputationRepository.UpdateReputationAsync(reputation);
        }

        public async Task DeleteReputationAsync(Guid id)
        {
            await _reputationRepository.DeleteReputationAsync(id);
        }
    }
}