using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository ?? throw new ArgumentNullException(nameof(scheduleRepository));
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _scheduleRepository.GetAllSchedulesAsync();
        }

        public async Task<Schedule> GetScheduleByIdAsync(Guid id)
        {
            return await _scheduleRepository.GetScheduleByIdAsync(id);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByUserIdAsync(Guid userId)
        {
            return await _scheduleRepository.GetSchedulesByUserIdAsync(userId);
        }

        public async Task AddScheduleAsync(Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            await _scheduleRepository.AddScheduleAsync(schedule);
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            await _scheduleRepository.UpdateScheduleAsync(schedule);
        }

        public async Task DeleteScheduleAsync(Guid id)
        {
            await _scheduleRepository.DeleteScheduleAsync(id);
        }
    }
}