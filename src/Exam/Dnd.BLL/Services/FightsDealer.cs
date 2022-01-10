using System;
using System.Collections.Generic;
using System.Text;
using Dnd.BLL.Models;

namespace Dnd.BLL.Services
{
    public static class FightsDealer
    {
        public static Random Random = new Random((int) DateTime.Now.Ticks);

        public static string GetFightLog(Character player, Character monster)
        {
            var stringBuilder = new StringBuilder();
            while(true)
            {
                if (CheckHps(player, monster, stringBuilder))
                    break;
                Attack(player, monster, stringBuilder);
                if (CheckHps(player, monster, stringBuilder))
                    break;
                Attack(monster, player, stringBuilder);
            }

            return stringBuilder.ToString();
        }

        private static void Attack(Character character1, Character character2, StringBuilder stringBuilder)
        {
            for (var i = 0; i < character1.AttackPerRound; i++)
            {
                var random = Random.Next(20) + 1;
                
                var modifiers = character1.AttackModifier + character1.Weapon;
                stringBuilder.Append($"{character1.Name} выкинул {random}(+{modifiers}) на атаку\r\n");
                
                if (random == 20)
                    stringBuilder.Append("Произошел крит\r\n");
                    
                if (random + modifiers <= character2.Ac) continue;
                stringBuilder.Append($"больше {character2.Ac}, попал\r\n");
                
                
                var damageRandom = 0;
                for (var j = 0; j < character1.Damage; ++j)
                    damageRandom += Random.Next(character1.DiceType) + 1;
                    
                   
                var damageModifiers = character1.Weapon + character1.DamageModifier;
                stringBuilder.Append($"выкинул {damageRandom}(+{damageModifiers}) на урон\r\n");
                
                
                character2.HitPoints -= (damageRandom + damageModifiers) * (random == 20 ? 2 : 1);
                stringBuilder.Append(
                    $"{character2.Name} теряет {(damageRandom + damageModifiers) * (random == 20 ? 2 : 1)} HP, остается {Math.Max(character2.HitPoints, 0)}\r\n");
                
                if(character2.HitPoints <= 0)
                    return;
            }
        }

        private static bool CheckHps(Character player, Character monster, StringBuilder stringBuilder)
        {
            if (player.HitPoints <= 0)
            {
                stringBuilder.Append($"{monster.Name} победил\r\n");
                return true;
            }

            if (monster.HitPoints <= 0)
            {
                stringBuilder.Append($"{player.Name} победил\r\n");
                return true;
            }

            return false;
        }
    }
}