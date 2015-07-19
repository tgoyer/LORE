using LORE.Entities.Characters;
using LORE.Entities.Mechanics.Rules;

namespace LORE.MiddeTier.Rules
{
    public static class RaceExtensions
    {
        public static void AssignRace(this CharacterBase character, RaceType type)
        {
            character.Race = type;
            AssignRacialSkills(character);
        }

        private static void AssignRacialSkills(CharacterBase character)
        {
            switch (character.Race)
            {
                case RaceType.Dwarf:
                    AssignDwarfSkills(character);
                    break;
                case RaceType.Elf:
                    AssignElfSkills(character);
                    break;
                case RaceType.Halfling:
                    AssignHalflingSkills(character);
                    break;
                case RaceType.Human:
                    AssignHumanSkills(character);
                    break;
                case RaceType.Orc:
                    AssignOrcSkills(character);
                    break;
            }
        }

        private static void AssignDwarfSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Constitution, 1);
            character.ModifyAbilityBy(AbilityType.Dexterity, -2);
            character.ModifyAbilityBy(AbilityType.Strength, 1);
            character.ModifyAbilityBy(AbilityType.Wisdom, 1);

            character.AddSkill(SkillType.LanguageDwarf, 100);
            character.AddSkill(SkillType.LanguageCommon, 25);
            character.AddSkill(SkillType.Block, 5);
            character.AddSkill(SkillType.Concentration, 5);
            character.AddSkill(SkillType.Fortitude, 10);
            character.AddSkill(SkillType.Leadership, 5);
            character.AddSkill(SkillType.Melee, 5);
            character.AddSkill(SkillType.Resistance, 10);
        }

        private static void AssignElfSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Constitution, -1);
            character.ModifyAbilityBy(AbilityType.Dexterity, 1);
            character.ModifyAbilityBy(AbilityType.Intelligence, 1);

            character.AddSkill(SkillType.LanguageElf, 100);
            character.AddSkill(SkillType.LanguageCommon, 25);
            character.AddSkill(SkillType.Casting, 10);
            character.AddSkill(SkillType.Concentration, 5);
            character.AddSkill(SkillType.Leadership, 5);
            character.AddSkill(SkillType.Perception, 5);
            character.AddSkill(SkillType.Ranged, 10);
            character.AddSkill(SkillType.Survival, 5);
        }

        private static void AssignHalflingSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Charisma, 1);
            character.ModifyAbilityBy(AbilityType.Constitution, -1);
            character.ModifyAbilityBy(AbilityType.Dexterity, 2);
            character.ModifyAbilityBy(AbilityType.Strength, -1);

            character.AddSkill(SkillType.LanguageHalfling, 100);
            character.AddSkill(SkillType.LanguageCommon, 25);
            character.AddSkill(SkillType.DualWield, 5);
            character.AddSkill(SkillType.Melee, 5);
            character.AddSkill(SkillType.Perception, 5);
            character.AddSkill(SkillType.Ranged, 5);
            character.AddSkill(SkillType.Reflex, 10);
            character.AddSkill(SkillType.Thievery, 10);
        }

        private static void AssignHumanSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Charisma, 1);

            character.AddSkill(SkillType.LanguageCommon, 100);
            character.AddSkill(SkillType.Block, 5);
            character.AddSkill(SkillType.Fortitude, 5);
            character.AddSkill(SkillType.Leadership, 10);
            character.AddSkill(SkillType.Melee, 10);
            character.AddSkill(SkillType.Ranged, 5);
            character.AddSkill(SkillType.Survival, 5);
        }

        private static void AssignOrcSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Charisma, -1);
            character.ModifyAbilityBy(AbilityType.Intelligence, -2);
            character.ModifyAbilityBy(AbilityType.Strength, 2);
            character.ModifyAbilityBy(AbilityType.Constitution, 2);

            character.AddSkill(SkillType.LanguageOrc, 100);
            character.AddSkill(SkillType.LanguageCommon, 25);
            character.AddSkill(SkillType.Block, 10);
            character.AddSkill(SkillType.DualWield, 5);
            character.AddSkill(SkillType.Fortitude, 10);
            character.AddSkill(SkillType.Melee, 5);
            character.AddSkill(SkillType.Resistance, 5);
            character.AddSkill(SkillType.Survival, 5);
        }
    }
}
