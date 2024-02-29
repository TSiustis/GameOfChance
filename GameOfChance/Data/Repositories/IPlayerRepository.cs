using GameOfChance.Models;

namespace GameOfChance.Data.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player?> GetPlayerByIdAsync(int playerId);
        Task UpdatePlayerBalanceAsync(Player player, int balanceChange);
    }
}
