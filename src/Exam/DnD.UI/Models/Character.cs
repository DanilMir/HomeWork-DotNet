using System.ComponentModel.DataAnnotations;

namespace DnD.UI.Models
{
    public class Character : Entity
    {
        public int Damage { get; set; }
        
        public int DamageModifier { get; set; }

        public int Weapon { get; set; }
    }
}