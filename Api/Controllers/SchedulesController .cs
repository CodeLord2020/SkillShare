using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService ?? throw new ArgumentNullException(nameof(scheduleService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleById(Guid id)
        {
            var schedule = await _scheduleService.GetScheduleByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedulesByUserId(Guid userId)
        {
            var schedules = await _scheduleService.GetSchedulesByUserIdAsync(userId);
            return Ok(schedules);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetAvailableSchedules(DateTime startTime, DateTime endTime)
        {
            var schedules = await _scheduleService.GetAvailableSchedulesAsync(startTime, endTime);
            return Ok(schedules);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> AddSchedule([FromBody] Schedule schedule)
        {
            if (schedule == null)
            {
                return BadRequest();
            }

            await _scheduleService.AddScheduleAsync(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.Id }, schedule);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSchedule(Guid id, [FromBody] Schedule schedule)
        {
            if (schedule == null || schedule.Id != id)
            {
                return BadRequest();
            }

            await _scheduleService.UpdateScheduleAsync(schedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSchedule(Guid id)
        {
            await _scheduleService.DeleteScheduleAsync(id);
            return NoContent();
        }
    }
}