namespace GameOfChance.Models
{
    public class BetResult
    {
        public int AccountBalance { get; set; }
        public bool Won { get; set; }
        public int PointsChange { get; set; }
        public int GeneratedNumber { get; set; }
        public string Status => Won ? "won" : "lost";
    }
}
