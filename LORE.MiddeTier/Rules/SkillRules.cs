using System;
using System.Linq;
using LORE.Entities.Characters;
using LORE.Entities.Mechanics.Rules;

namespace LORE.MiddeTier.Rules
{
    public static class SkillRulesExtensions
    {
        public static bool SkillExists(this CharacterBase character, SkillType type)
        {
            return character.Skills.Exists(s => s.Type == type);
        }

        public static void AddSkill(this CharacterBase character, SkillType type)
        {
            var skill = character.GetSkill(type);
            if (skill != null) throw new Exception("Skill is already set.");

            character.Skills.Add(new Skill(type, GetAbilityModifier(type), 0));
        }

        public static void AddSkill(this CharacterBase character, SkillType type, int value)
        {
            if ( !character.SkillExists(type) )
            {
                character.AddSkill(type);
                character.SetSkillValue(type, value);
            }
        }

        public static void SetSkillValue(this CharacterBase character, SkillType type, int value)
        {
            foreach (var skill in character.Skills)
            {
                if (skill.Type != type) continue;

                skill.Value = value;
                break;
            }
        }

        public static Skill GetSkill(this CharacterBase character, SkillType skillType)
        {
            return character.Skills.FirstOrDefault(s => s.Type == skillType);
        }

        public static int GetSkillScore(this CharacterBase character, SkillType skillType)
        {
            var skill = character.GetSkill(skillType);
            if (skill == null) return 0;

            var abilityRule = character.GetAbilityScore(skill.SkillModifier);
            return skill.Value + abilityRule.Modifier;
        }

        private static AbilityType GetAbilityModifier(SkillType type)
        {
            switch (type)
            {
                case SkillType.Block: 
                    return AbilityType.Strength;
                case SkillType.Casting: 
                    return AbilityType.Intelligence;
                case SkillType.Concentration:
                    return AbilityType.Intelligence;
                case SkillType.DualWield:
                    return AbilityType.Dexterity;
                case SkillType.Fortitude:
                    return AbilityType.Constitution;
                case SkillType.LanguageCommon:
                    return AbilityType.Intelligence;
                case SkillType.LanguageDwarf:
                    return AbilityType.Intelligence;
                case SkillType.LanguageElf:
                    return AbilityType.Intelligence;
                case SkillType.LanguageHalfling:
                    return AbilityType.Intelligence;
                case SkillType.LanguageOrc:
                    return AbilityType.Intelligence;
                case SkillType.Leadership:
                    return AbilityType.Charisma;
                case SkillType.Melee:
                    return AbilityType.Strength;
                case SkillType.Perception:
                    return AbilityType.Wisdom;
                case SkillType.Ranged:
                    return AbilityType.Dexterity;
                case SkillType.Reflex:
                    return AbilityType.Dexterity;
                case SkillType.Resistance:
                    return AbilityType.Constitution;
                case SkillType.Survival:
                    return AbilityType.Wisdom;
                case SkillType.Thievery:
                    return AbilityType.Dexterity;
            }
            throw new Exception("AbilityType not found.");
        }
    }
}
