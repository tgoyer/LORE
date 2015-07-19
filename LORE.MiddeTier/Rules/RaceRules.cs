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
                case RaceType.Goblin:
                    AssignGoblinSkills(character);
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
            AddSkill(character, SkillType.LanguageDwarf, 100);

            AddSkill(character, SkillType.Block, 5);
            AddSkill(character, SkillType.Concentration, 5);
            AddSkill(character, SkillType.Fortitude, 10);
            AddSkill(character, SkillType.Leadership, 5);
            AddSkill(character, SkillType.Melee, 5);
            AddSkill(character, SkillType.Resistance, 10);
        }

        private static void AssignElfSkills(CharacterBase character)
        {
            AddSkill(character, SkillType.LanguageElf, 100);

            AddSkill(character, SkillType.Casting, 10);
            AddSkill(character, SkillType.Concentration, 5);
            AddSkill(character, SkillType.Leadership, 5);
            AddSkill(character, SkillType.Perception, 5);
            AddSkill(character, SkillType.Ranged, 10);
            AddSkill(character, SkillType.Survival, 5);
        }

        private static void AssignGoblinSkills(CharacterBase character)
        {
            AddSkill(character, SkillType.LanguageGoblin, 100);

            AddSkill(character, SkillType.DualWield, 5);
            AddSkill(character, SkillType.Melee, 5);
            AddSkill(character, SkillType.Perception, 5);
            AddSkill(character, SkillType.Ranged, 5);
            AddSkill(character, SkillType.Reflex, 10);
            AddSkill(character, SkillType.Thievery, 10);
        }

        private static void AssignHumanSkills(CharacterBase character)
        {
            AddSkill(character, SkillType.LanguageCommon, 100);

            AddSkill(character, SkillType.Block, 5);
            AddSkill(character, SkillType.Fortitude, 5);
            AddSkill(character, SkillType.Leadership, 10);
            AddSkill(character, SkillType.Melee, 10);
            AddSkill(character, SkillType.Ranged, 5);
            AddSkill(character, SkillType.Survival, 5);
        }

        private static void AssignOrcSkills(CharacterBase character)
        {
            AddSkill(character, SkillType.LanguageOrc, 100);

            AddSkill(character, SkillType.Block, 10);
            AddSkill(character, SkillType.DualWield, 5);
            AddSkill(character, SkillType.Fortitude, 10);
            AddSkill(character, SkillType.Melee, 5);
            AddSkill(character, SkillType.Resistance, 5);
            AddSkill(character, SkillType.Survival, 5);
        }

        private static void AddSkill(CharacterBase character, SkillType type, int value)
        {
            if (!(character.Skills.Exists(s => s.Type == type)))
            {
                character.AddSkill(type, value);
            }
        }
    }
}
