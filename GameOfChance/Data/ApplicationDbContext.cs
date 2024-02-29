using GameOfChance.Models;
using Microsoft.EntityFrameworkCore;

namespace GameOfChance.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Bet> Bets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }

}
