﻿using Dnd.BLL.Models;

namespace Dnd.BLL.Services
{
    public class CharacterCalculator
    {
        public static CalculatedCharacterModel CalculateCharacter(CharacterModel character)
        {
            return new CalculatedCharacterModel()
            {
                Name = character.Name,
                HitPoints = character.HitPoints,
                AttackModifier = character.AttackModifier,
                AttackPerRound = character.AttackPerRound,
                Damage = character.Damage,
                DiceType = character.DiceType,
                DamageModifier = character.DamageModifier,
                Weapon = character.Weapon,
                ArmorClass = character.ArmorClass,
                MinAcToAlwaysHit = character.AttackModifier + character.Weapon + 1,
                DamagePerRoundLeft = (character.Damage + character.Weapon + character.DamageModifier) *
                                     character.AttackPerRound,
                DamagePerRoundRight = (character.DiceType + character.Weapon + character.DamageModifier) *
                                      character.AttackPerRound
            };
        }
    }
}