using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Entities;

namespace SkillShare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAddonController : ControllerBase
    {
        private readonly IUserAddOnService _userAddonService;

        public UserAddonController(IUserAddOnService userAddonService)
        {
            _userAddonService = userAddonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAddonsAsync()
        {
            var userAddons = await _userAddonService.GetAllUserAddOnsAsync();
            return Ok(userAddons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAddonByIdAsync(Guid id)
        {
            var userAddon = await _userAddonService.GetUserAddOnByIdAsync(id);
            return Ok(userAddon);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserAddonsByUserIdAsync(Guid userId)
        {
            var userAddons = await _userAddonService.GetUserAddOnsByUserIdAsync(userId);
            return Ok(userAddons);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAddonAsync([FromBody] UserAddOn userAddon)
        {
            await _userAddonService.AddUserAddOnAsync(userAddon);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAddonAsync([FromBody] UserAddOn userAddon)
        {
            await _userAddonService.UpdateUserAddOnAsync(userAddon);
            return Ok();
        }

        [HttpDelete("{id}")]  
        public async Task<IActionResult> DeleteUserAddonAsync(Guid id)
        {
            await _userAddonService.DeleteUserAddOnAsync(id);
            return Ok();
        }

    }
}