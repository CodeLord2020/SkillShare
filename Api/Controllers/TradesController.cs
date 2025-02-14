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
    public class TradesController : ControllerBase
    {
        private readonly ITradeService _tradeService;

        public TradesController(ITradeService tradeService)
        {
            _tradeService = tradeService ?? throw new ArgumentNullException(nameof(tradeService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trade>>> GetAllTrades()
        {
            var trades = await _tradeService.GetAllTradesAsync();
            return Ok(trades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trade>> GetTradeById(Guid id)
        {
            var trade = await _tradeService.GetTradeByIdAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            return Ok(trade);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Trade>>> GetTradesByUserId(Guid userId)
        {
            var trades = await _tradeService.GetTradesByUserIdAsync(userId);
            return Ok(trades);
        }

        [HttpPost]
        public async Task<ActionResult<Trade>> AddTrade([FromBody] Trade trade)
        {
            if (trade == null)
            {
                return BadRequest();
            }

            await _tradeService.AddTradeAsync(trade);
            return CreatedAtAction(nameof(GetTradeById), new { id = trade.Id }, trade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTrade(Guid id, [FromBody] Trade trade)
        {
            if (trade == null || trade.Id != id)
            {
                return BadRequest();
            }

            await _tradeService.UpdateTradeAsync(trade);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTrade(Guid id)
        {
            await _tradeService.DeleteTradeAsync(id);
            return NoContent();
        }
    }
}