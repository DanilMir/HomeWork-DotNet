namespace Dnd.DB.Models
{
    public class Entity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int HitPoints { get; set; }

        public int AttackModifier { get; set; }
        
        public int CountOfAttack { get; set; } //"2"d8
        
        public int DiceType { get; set; } //1d"20"
        
        public int ArmorClass { get; set; }

        public int AttackPerRound { get; set; }
    }
}