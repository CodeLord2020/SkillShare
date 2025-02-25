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
    public class UserAddOnRepository : IUserAddOnRepository
    {
        private readonly AppDbContext _context;

        public UserAddOnRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserAddOn>> GetUserAddOnsByUserIdAsync(Guid userId)
        {
            return await _context.UserAddOns
                .Where(ua => ua.UserId == userId)
                .ToListAsync();
        }

        public async Task AddUserAddOnAsync(UserAddOn userAddOn)
        {
            await _context.UserAddOns.AddAsync(userAddOn);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAddOnAsync(Guid id)
        {
            var userAddOn = await _context.UserAddOns.FindAsync(id);
            if (userAddOn != null)
            {
                _context.UserAddOns.Remove(userAddOn);
                await _context.SaveChangesAsync();
            }
        }
    }
}