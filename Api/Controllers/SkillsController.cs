using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService ?? throw new ArgumentNullException(nameof(skillService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetAllSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkillById(Guid id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkillsByUserId(Guid userId)
        {
            var skills = await _skillService.GetSkillsByUserIdAsync(userId);
            return Ok(skills);
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> AddSkill([FromBody] Skill skill)
        {
            if (skill == null)
            {
                return BadRequest();
            }
            await _skillService.AddSkillAsync(skill);
            return CreatedAtAction(nameof(GetSkillById), new { id = skill.Id }, skill);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSkill(Guid id, [FromBody] Skill skill)
        {
            if (skill == null || skill.Id != id)
            {
                return BadRequest();
            }

            await _skillService.UpdateSkillAsync(skill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkill(Guid id)
        {
            await _skillService.DeleteSkillAsync(id);
            return NoContent();
        }

    }
}