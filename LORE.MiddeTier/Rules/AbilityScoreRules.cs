﻿using System;
using System.Collections.Generic;
using System.Linq;
using LORE.Entities.Characters;
using LORE.Entities.Mechanics.Rules;

namespace LORE.MiddeTier.Rules
{
    public class AbilityScoreRules
    {
        private readonly List<AbilityScore> rules = new List<AbilityScore>();

        public AbilityScoreRules()
        {
            rules.AddRange(new List<AbilityScore>
            {
                new AbilityScore(-6, "Useless", "Good luck"),
                new AbilityScore(-5, "Abysmal", "Severely Handicapped"),
                new AbilityScore(-4, "Awful", "Severely Impaired"),
                new AbilityScore(-3, "Bad", "Impaired"),
                new AbilityScore(-2, "Poor", "Significantly Below Average"),
                new AbilityScore(-1, "Mediocre", "Below Average"),
                new AbilityScore(0, "Fair", "Average or Normal"),
                new AbilityScore(1, "Good", "Above Average"),
                new AbilityScore(2, "Great", "Significantly Above Average"),
                new AbilityScore(3, "Exceptional", "Gifted"),
                new AbilityScore(4, "Amazing", "Highly Gifted"),
                new AbilityScore(5, "Phenominal", "Exceptionally Gifted"),
                new AbilityScore(6, "Prodigy", "The Best of The Best")
            });
        }

        public AbilityScore GetRule(int modifier)
        {
            return rules.Find(r => r.Modifier == modifier);
        }

        public AbilityScore GetRuleByStatValue(int roll)
        {
            var rule = default(AbilityScore);

            if (roll < 0) roll = 0;
            if (roll > 25) roll = 25;

            switch (roll)
            {
                case 0: 
                case 1:
                    rule = GetRule(-6);
                    break;
                case 2: 
                case 3:
                    rule = GetRule(-5);
                    break;
                case 4:
                case 5:
                    rule = GetRule(-4);
                    break;
                case 6:
                case 7:
                    rule = GetRule(-3);
                    break;
                case 8:
                case 9:
                    rule = GetRule(-2);
                    break;
                case 10:
                case 11:
                    rule = GetRule(-1);
                    break;
                case 12:
                case 13:
                    rule = GetRule(0);
                    break;
                case 14:
                case 15:
                    rule = GetRule(1);
                    break;
                case 16:
                case 17:
                    rule = GetRule(2);
                    break;
                case 18:
                case 19:
                    rule = GetRule(3);
                    break;
                case 20:
                case 21:
                    rule = GetRule(4);
                    break;
                case 22:
                case 23:
                    rule = GetRule(5);
                    break;
                case 24:
                case 25:
                    rule = GetRule(6);
                    break;
            }
            return rule;
        }
    }


    public static class AbilityScoreRulesExtensions
    {
        public static void AddAbility(this CharacterBase character, AbilityType type)
        {
            var ability = character.GetAbility(type);
            if (ability != null) throw new Exception("Ability is already set.");

            character.Abilities.Add(new Ability(type, 10));
        }

        public static Ability GetAbility(this CharacterBase character, AbilityType type)
        {
            return character.Abilities.FirstOrDefault(a => a.Type == type);
        }

        public static AbilityScore GetAbilityScore(this CharacterBase character, AbilityType type)
        {
            var rules = new AbilityScoreRules();
            return rules.GetRuleByStatValue(character.GetAbility(type).Value);
        }

        public static void ModifyAbilityBy(this CharacterBase character, AbilityType type, int value)
        {
            foreach (var t in character.Abilities)
            {
                if (t.Type == type)
                {
                    t.Value += value;
                    break;
                }
            }
        }
    }
}
