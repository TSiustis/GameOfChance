using GameOfChance.Models;

namespace GameOfChance.Services
{
    public interface IGameService
    {
        Task<BetResult> ProcessBetAsync(BetRequestDTO betRequest);
    }
}
