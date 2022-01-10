using System.ComponentModel.DataAnnotations;

namespace Dnd.DB.Models
{
    public class Monster : Entity
    {
        public int Damage { get; set; }
        public int DamageModifier { get; set; }
        public int Weapon { get; set; }
    }
}