using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
        Task<Schedule> GetScheduleByIdAsync(Guid id);
        Task<IEnumerable<Schedule>> GetSchedulesByUserIdAsync(Guid userId);
        Task<IEnumerable<Schedule>> GetAvailableSchedulesAsync(DateTime startTime, DateTime endTime);
        Task AddScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(Guid id);
    }
}