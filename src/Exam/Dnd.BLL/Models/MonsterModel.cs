using System.ComponentModel.DataAnnotations;

namespace Dnd.BLL.Models
{
    public class MonsterModel : EntityModel
    {
        public int Damage { get; set; }
        public int DamageModifier { get; set; }
        public int Weapon { get; set; }
    }
}