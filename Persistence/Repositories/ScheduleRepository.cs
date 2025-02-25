using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;
using SkillShare.Domain.ValueObjects;
using SkillShare.Persistence.Data;

namespace SkillShare.Persistence.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _appDbContext;

        public ScheduleRepository(AppDbContext context)
        {
            _appDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _appDbContext.Schedules.ToListAsync();
        }

        public async Task<Schedule> GetScheduleByIdAsync(Guid id)
        {
            var schedule = await _appDbContext.Schedules.FindAsync(id);
            return schedule ?? throw new Exception($"User with id: {id} not found.");
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByUserIdAsync(Guid userId)
        {
            return await _appDbContext.Schedules
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetAvailableSchedulesAsync(TimeSlot timeSlot)
        {
            return await _appDbContext.Schedules
                .Where(s => s.IsAvailable && s.TimeSlot != null && s.TimeSlot.Overlaps(timeSlot))
                .ToListAsync();
        }

        public async Task AddScheduleAsync(Schedule schedule)
        {
            await _appDbContext.Schedules.AddAsync(schedule);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            _appDbContext.Schedules.Update(schedule);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteScheduleAsync(Guid id)
        {
            var schedule = await _appDbContext.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _appDbContext.Schedules.Remove(schedule);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}