// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using SkillShare.Domain.Entities;
// using SkillShare.Persistence.Data;

// namespace SkillShare.Persistence.Repositories
// {
//     public class SkillRepository
//     {
//         private readonly AppDbContext _context;

//         public SkillRepository(AppDbContext context)
//         {
//             _context = context ?? throw new ArgumentNullException(nameof(context));
//         }

//         public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
//         {
//             return await _context.Skills.ToListAsync();
//         }

//         public async Task<Skill> GetSkillByIdAsync(Guid id)
//         {
//             return await _context.Skills.FindAsync(id);
//         }

//         public async Task<IEnumerable<Skill>> GetSkillsByUserIdAsync(Guid userId)
//         {
//             return await _context.Skills
//                 .Where(s => s.UserId == userId)
//                 .ToListAsync();
//         }

//         public async Task AddSkillAsync(Skill skill)
//         {
//             await _context.Skills.AddAsync(skill);
//             await _context.SaveChangesAsync();
//         }

//         public async Task UpdateSkillAsync(Skill skill)
//         {
//             _context.Skills.Update(skill);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteSkillAsync(Guid id)
//         {
//             var skill = await _context.Skills.FindAsync(id);
//             if (skill != null)
//             {
//                 _context.Skills.Remove(skill);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }
// }