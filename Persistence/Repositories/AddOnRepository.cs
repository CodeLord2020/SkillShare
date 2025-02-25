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
    public class AddOnRepository : IAddOnRepository
    {
        private readonly AppDbContext _context;

        public AddOnRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddOn>> GetAllAddOnsAsync()
        {
            return await _context.AddOns.ToListAsync();
        }

        public async Task<AddOn> GetAddOnByIdAsync(Guid id)
        {
            var addOn = await _context.AddOns.FindAsync(id) ?? throw new KeyNotFoundException($"AddOn with id {id} not found.");
            return addOn;
        }

        public async Task AddAddOnAsync(AddOn addOn)
        {
            await _context.AddOns.AddAsync(addOn);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddOnAsync(AddOn addOn)
        {
            _context.AddOns.Update(addOn);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddOnAsync(Guid id)
        {
            var addOn = await _context.AddOns.FindAsync(id);
            if (addOn != null)
            {
                _context.AddOns.Remove(addOn);
                await _context.SaveChangesAsync();
            }
        }
    }
}