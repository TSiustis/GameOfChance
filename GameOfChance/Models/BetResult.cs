namespace GameOfChance.Models
{
    public class BetResult
    {
        public int AccountBalance { get; set; }
        public int PointsChange { get; set; }
        public int GeneratedNumber { get; set; }
        public string? Status { get; set; }
    }
}
