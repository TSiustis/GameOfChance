using GameOfChance.Models;
using GameOfChance.Models.Constants;
using GameOfChance.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameOfChance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetsController : ControllerBase
    {
        private readonly IGameService _gameService;

        public BetsController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<BetResult>> PlaceBet([FromBody] BetRequestDTO betRequest)
        {
            if (betRequest.NumberPredicted < 0  || betRequest.NumberPredicted > 9)
            {
                return BadRequest(BetConstants.InvalidNumberEntered);
            }

            try
            {
                var betResult = await _gameService.ProcessBetAsync(betRequest);
                return Ok(betResult);
            }
            catch (Exception ex)
            {
                // Better exception handling can be implemented here
                return BadRequest(ex.Message);
            }
        }
    }
}