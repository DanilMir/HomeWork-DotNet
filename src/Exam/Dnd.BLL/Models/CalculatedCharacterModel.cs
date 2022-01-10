namespace Dnd.BLL.Models
{
    public class CalculatedCharacterModel : CharacterModel
    {
        public int MinAcToAlwaysHit { get; set; }
        public int DamagePerRoundLeft { get; set; }
        public int DamagePerRoundRight { get; set; }
    }
}