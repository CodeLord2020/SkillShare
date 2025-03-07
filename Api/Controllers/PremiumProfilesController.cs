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
    public class PremiumProfilesController : ControllerBase
    {
         private readonly IPremiumProfileService _premiumProfileService;

        public PremiumProfilesController(IPremiumProfileService premiumProfileService)
        {
            _premiumProfileService = premiumProfileService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PremiumProfile>>> GetAllPremiumProfiles()
        {
            var premiumProfiles = await _premiumProfileService.GetAllPremiumProfilesAsync();
            return Ok(premiumProfiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PremiumProfile>> GetPremiumProfileById(Guid id)
        {
            var premiumProfile = await _premiumProfileService.GetPremiumProfileByIdAsync(id);
            if (premiumProfile == null)
            {
                return NotFound();
            }
            return Ok(premiumProfile);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<PremiumProfile>> GetPremiumProfileByUserId(Guid userId)
        {
            var premiumProfile = await _premiumProfileService.GetPremiumProfileByUserIdAsync(userId);
            if (premiumProfile == null)
            {
                return NotFound();
            }
            return Ok(premiumProfile);
        }

        [HttpPost]
        public async Task<ActionResult<PremiumProfile>> AddPremiumProfile([FromBody] PremiumProfile premiumProfile)
        {
            if (premiumProfile == null)
            {
                return BadRequest();
            }

            await _premiumProfileService.AddPremiumProfileAsync(premiumProfile);
            return CreatedAtAction(nameof(GetPremiumProfileById), new { id = premiumProfile.Id }, premiumProfile);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePremiumProfile(Guid id, [FromBody] PremiumProfile premiumProfile)
        {
            if (premiumProfile == null || premiumProfile.Id != id)
            {
                return BadRequest();
            }

            await _premiumProfileService.UpdatePremiumProfileAsync(premiumProfile);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePremiumProfile(Guid id)
        {
            await _premiumProfileService.DeletePremiumProfileAsync(id);
            return NoContent();
        }
    }
}