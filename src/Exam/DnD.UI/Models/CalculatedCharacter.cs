namespace DnD.UI.Models
{
    public class CalculatedCharacter : Character
    {
        public int MinAcToAlwaysHit { get; set; }
        public int DamagePerRoundLeft { get; set; }
        public int DamagePerRoundRight { get; set; }
    }
}