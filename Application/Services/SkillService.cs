using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await _skillRepository.GetAllSkillsAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(Guid id)
        {
            return await _skillRepository.GetSkillByIdAsync(id);
        }

        public async Task<IEnumerable<Skill>> GetSkillsByUserIdAsync(Guid userId)
        {
            return await _skillRepository.GetSkillsByUserIdAsync(userId);
        }

        public async Task AddSkillAsync(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            await _skillRepository.AddSkillAsync(skill);
        }

        public async Task UpdateSkillAsync(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            await _skillRepository.UpdateSkillAsync(skill);
        }

        public async Task DeleteSkillAsync(Guid id)
        {
            await _skillRepository.DeleteSkillAsync(id);
        }

    }
}