using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;
using SkillShare.Persistence.Data;

namespace SkillShare.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _appDbContext;

        public SkillRepository(AppDbContext context)
        {
            _appDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            var skill = await _appDbContext.Skills.ToListAsync();
            return skill;
            // ?? throw new Exception($"Skill with id: {id} not found.");
        }

        public async Task<Skill> GetSkillByIdAsync(Guid id)
        {
            var skill = await _appDbContext.Skills.FindAsync(id);
            return skill ?? throw new Exception($"Skill with id: {id} not found.");;
        }

        public async Task<IEnumerable<Skill>> GetSkillsByUserIdAsync(Guid userId)
        {
            return await _appDbContext.Skills
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task AddSkillAsync(Skill skill)
        {
            await _appDbContext.Skills.AddAsync(skill);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateSkillAsync(Skill skill)
        {
            _appDbContext.Skills.Update(skill);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteSkillAsync(Guid id)
        {
            var skill = await _appDbContext.Skills.FindAsync(id);
            if (skill != null)
            {
                _appDbContext.Skills.Remove(skill);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}