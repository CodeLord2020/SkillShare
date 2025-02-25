using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Services
{
    public class AddOnService : IAddOnService
    {
        private readonly IAddOnRepository _addOnRepository;

        public AddOnService(IAddOnRepository addOnRepository)
        {
            _addOnRepository = addOnRepository;
        }

        public async Task<IEnumerable<AddOn>> GetAllAddOnsAsync()
        {
            return await _addOnRepository.GetAllAddOnsAsync();
        }

        public async Task<AddOn> GetAddOnByIdAsync(Guid id)
        {
            return await _addOnRepository.GetAddOnByIdAsync(id);
        }

        public async Task AddAddOnAsync(AddOn addOn)
        {
            await _addOnRepository.AddAddOnAsync(addOn);
        }

        public async Task UpdateAddOnAsync(AddOn addOn)
        {
            await _addOnRepository.UpdateAddOnAsync(addOn);
        }

        public async Task DeleteAddOnAsync(Guid id)
        {
            await _addOnRepository.DeleteAddOnAsync(id);
        }
    }
}