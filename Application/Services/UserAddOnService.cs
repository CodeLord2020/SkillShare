using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Services
{
    public class UserAddOnService : IUserAddOnService
    {
        private readonly IUserAddOnRepository _userAddOnRepository;
        
        public UserAddOnService(IUserAddOnRepository userAddOnRepository)
        {
            _userAddOnRepository = userAddOnRepository;
        }

        public async Task<IEnumerable<UserAddOn>> GetAllUserAddOnsAsync()
        {
            return await _userAddOnRepository.GetAllUserAddOnsAsync();
        }

        public async Task<UserAddOn> GetUserAddOnByIdAsync(Guid id)
        {
            return await _userAddOnRepository.GetUserAddOnByIdAsync(id);
        }

        public async Task<IEnumerable<UserAddOn>> GetUserAddOnsByUserIdAsync(Guid userId)
        {
            return await _userAddOnRepository.GetUserAddOnsByUserIdAsync(userId);
        }

        public async Task AddUserAddOnAsync(UserAddOn userAddOn)
        {
            await _userAddOnRepository.AddUserAddOnAsync(userAddOn);
        }
        
        public async Task UpdateUserAddOnAsync(UserAddOn userAddOn)
        {
            await _userAddOnRepository.UpdateUserAddOnAsync(userAddOn);
        }

        public async Task DeleteUserAddOnAsync(Guid id)
        {
            await _userAddOnRepository.DeleteUserAddOnAsync(id);
        }
    }
}