using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Interfaces
{
    public interface IReputationService
    {
        Task<IEnumerable<Reputation>> GetAllReputationsAsync();
        Task<Reputation> GetReputationByIdAsync(Guid id);
        Task<Reputation> GetReputationByUserIdAsync(Guid userId);
        Task AddReputationAsync(Reputation reputation);
        Task UpdateReputationAsync(Reputation reputation);
        Task DeleteReputationAsync(Guid id);
    }
}