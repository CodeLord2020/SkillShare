using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Interfaces
{
    public interface IUserAddOnService
    {
        Task<IEnumerable<UserAddOn>> GetAllUserAddOnsAsync();
        Task<UserAddOn> GetUserAddOnByIdAsync(Guid id);
        Task<IEnumerable<UserAddOn>> GetUserAddOnsByUserIdAsync(Guid userId);
        Task AddUserAddOnAsync(UserAddOn userAddOn);
        Task UpdateUserAddOnAsync(UserAddOn userAddOn);
        Task DeleteUserAddOnAsync(Guid id);
    }
}