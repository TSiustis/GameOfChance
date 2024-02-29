using GameOfChance.Data.Repositories;
using GameOfChance.Models;
using GameOfChance.Models.Constants;
using GameOfChance.Models.CustomExceptions;
using System.Numerics;

namespace GameOfChance.Services
{
    public class GameService : IGameService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly Random _random = new();

        public GameService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<BetResult> ProcessBetAsync(BetRequestDTO betRequest)
        {
            if (betRequest.NumberPredicted < 0 || betRequest.NumberPredicted > 9)
            {
                throw new AppException(BetConstants.InvalidNumberEntered);
            }

            var player = await _playerRepository.GetPlayerByIdAsync(betRequest.PlayerId)
                ?? throw new KeyNotFoundException(BetConstants.PlayerNotFound);

            ValidateBetAmount(betRequest.Points, player.AccountBalance);

            var generatedNumber = _random.Next(0, 10);
            bool won = generatedNumber == betRequest.NumberPredicted;
            var pointsChange = CalculatePointsChange(betRequest.Points, won);

            await _playerRepository.UpdatePlayerBalanceAsync(player, pointsChange);

            return new BetResult
            {
                AccountBalance = player.AccountBalance,
                PointsChange = pointsChange,
                GeneratedNumber = generatedNumber,
                Status = won ? "won" : "lost"
            };
        }

        private static void ValidateBetAmount(int points, int accountBalance)
        {

            if (points > accountBalance)
            {
                throw new AppException(BetConstants.BetExceededAccountAmount);
            }

            if (points < 0)
            {
                throw new AppException(BetConstants.BetLowerThanZero);
            }
        }

        private static int CalculatePointsChange(int points, bool won) => won ? points * 9 : -points;
    }
} 