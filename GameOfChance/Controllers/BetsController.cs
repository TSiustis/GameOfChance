using GameOfChance.Models;
using GameOfChance.Models.Constants;
using GameOfChance.Models.CustomExceptions;
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
            try
            {
                var betResult = await _gameService.ProcessBetAsync(betRequest);
                return Ok(betResult);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
    }
}