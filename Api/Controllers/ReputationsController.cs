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
    public class ReputationsController : ControllerBase
    {
        private readonly IReputationService _reputationService;

        public ReputationsController(IReputationService reputationService)
        {
            _reputationService = reputationService ?? throw new ArgumentNullException(nameof(reputationService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reputation>>> GetAllReputations()
        {
            var reputations = await _reputationService.GetAllReputationsAsync();
            return Ok(reputations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reputation>> GetReputationById(Guid id)
        {
            var reputation = await _reputationService.GetReputationByIdAsync(id);
            if (reputation == null)
            {
                return NotFound();
            }
            return Ok(reputation);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Reputation>> GetReputationByUserId(Guid userId)
        {
            var reputation = await _reputationService.GetReputationByUserIdAsync(userId);
            if (reputation == null)
            {
                return NotFound();
            }
            return Ok(reputation);
        }

        [HttpPost]
        public async Task<ActionResult<Reputation>> AddReputation([FromBody] Reputation reputation)
        {
            if (reputation == null)
            {
                return BadRequest();
            }

            await _reputationService.AddReputationAsync(reputation);
            return CreatedAtAction(nameof(GetReputationById), new { id = reputation.Id }, reputation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReputation(Guid id, [FromBody] Reputation reputation)
        {
            if (reputation == null || reputation.Id != id)
            {
                return BadRequest();
            }

            await _reputationService.UpdateReputationAsync(reputation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReputation(Guid id)
        {
            await _reputationService.DeleteReputationAsync(id);
            return NoContent();
        }
    }
}