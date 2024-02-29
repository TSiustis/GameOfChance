using GameOfChance.Data;
using GameOfChance.Models;

namespace GameOfChance
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Players.Any())
            {
                return;
            }

            var players = new Player[]
            {
                new() {AccountBalance=10000},
                new() {AccountBalance=10000},
            };

            foreach (Player p in players)
            {
                context.Players.Add(p);
            }

            context.SaveChanges();
        }
    }
}
