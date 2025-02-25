using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Interfaces
{
    public interface IAddOnService
    {
        Task<IEnumerable<AddOn>> GetAllAddOnsAsync();
        Task<AddOn> GetAddOnByIdAsync(Guid id);
        Task AddAddOnAsync(AddOn addOn);
        Task UpdateAddOnAsync(AddOn addOn);
        Task DeleteAddOnAsync(Guid id);     
    }
}