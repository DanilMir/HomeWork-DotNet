using System;
using System.Collections.Generic;
using Dnd.BLL.Models;

namespace Dnd.BLL.Services
{
    public class FightDecider
    {
        private static readonly Dictionary<Guid, Fight> fights = new();

        private static readonly Random Random = new Random((int) DateTime.Now.Ticks);

        public static Fight MakeTurn(Guid fightId)
        {
            if (!fights.ContainsKey(fightId)) throw new Exception();
            var fight = fights[fightId];
            var player = fight.Player;
            var monster = fight.Monster;
            for (var i = 0; i < player.AttackPerRound; i++)
            {
                var random = Random.Next(player.DiceType) + 1;
                monster.HitPoints -= random + player.Weapon + player.DamageModifier;
                if (monster.HitPoints <= 0)
                {
                    fight.PlayerWon = true;
                    break;
                }
            }

            if (fight.PlayerWon is not null && (bool) fight.PlayerWon) return fight;
            for (var i = 0; i < monster.AttackPerRound; i++)
            {
                var random = Random.Next(monster.DiceType) + 1;
                player.HitPoints -= random + monster.Weapon + monster.DamageModifier;
                if (player.HitPoints <= 0)
                {
                    fight.PlayerWon = false;
                    break;
                }
            }

            return fight;
        }

        public static Guid CreateFight(FightsController.FightStartingModel model)
        {
            var guid = Guid.NewGuid();
            var (player, monster) = model;
            var fight = new Fight
            {
                FightId = guid,
                Player = player,
                Monster = monster,
                PlayerWon = null
            };
            fights.Add(guid, fight);
            return guid;
        }
    }
}