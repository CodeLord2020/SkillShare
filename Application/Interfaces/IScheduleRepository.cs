using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
        Task<Schedule> GetScheduleByIdAsync(Guid id);
        Task<IEnumerable<Schedule>> GetSchedulesByUserIdAsync(Guid userId);
        Task AddScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(Guid id);
    }
}