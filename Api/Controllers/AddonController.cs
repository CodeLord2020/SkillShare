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
    public class AddonController : ControllerBase
    {
        private readonly IAddOnService _addOnService;

        public AddonController(IAddOnService addOnService)
        {
            _addOnService = addOnService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAddOnsAsync()
        {
            var addOns = await _addOnService.GetAllAddOnsAsync();
            return Ok(addOns);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddOnByIdAsync(Guid id)
        {
            var addOn = await _addOnService.GetAddOnByIdAsync(id);
            return Ok(addOn);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddOnAsync([FromBody] AddOn addOn)
        {
            await _addOnService.AddAddOnAsync(addOn);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddOnAsync([FromBody] AddOn addOn)
        {
            await _addOnService.UpdateAddOnAsync(addOn);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddOnAsync(Guid id)
        {
            await _addOnService.DeleteAddOnAsync(id);
            return Ok();
        }
    }
}