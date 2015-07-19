using LORE.Common.Enums;
using LORE.Entities.Characters;
using LORE.Entities.Mechanics.Rules;

namespace LORE.MiddeTier.Rules
{
    public static class ClassExtensions
    {
        public static void AssignClass(this CharacterBase character, ClassType type)
        {
            character.Class = type;

            AssignClassSkills(character, type);
        }

        private static void AssignClassSkills(CharacterBase character, ClassType type)
        {
            switch (type)
            {
                case ClassType.Bard:
                    AssignBardSkills(character);
                    break;
                case ClassType.Berserker:
                    AssignBerserkerSkills(character);
                    break;
                case ClassType.Crusader:
                    AssignCrusaderSkills(character);
                    break;
                case ClassType.Elementalist:
                    AssignElementalistSkills(character);
                    break;
                case ClassType.Monk:
                    AssignMonkSkills(character);
                    break;
                case ClassType.Priest:
                    AssignPriestSkills(character);
                    break;
                case ClassType.Ranger:
                    AssignRangerSkills(character);
                    break;
                case ClassType.Rogue:
                    AssignRogueSkills(character);
                    break;
            }
        }

        private static void AssignBardSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Charisma, 1);
            character.ModifyAbilityBy(AbilityType.Dexterity, 1);

            AddArmorProficiency(character, ArmorCategoryType.LightArmor);
            AddArmorProficiency(character, ArmorCategoryType.MediumArmor);

            AddWeaponProficiency(character, WeaponCategoryType.Daggers);
            AddWeaponProficiency(character, WeaponCategoryType.Swords);
            AddWeaponProficiency(character, WeaponCategoryType.ShortBow);
            AddWeaponProficiency(character, WeaponCategoryType.CrossBow);

            AddSkill(character, SkillType.Casting, 10);
            AddSkill(character, SkillType.Concentration, 10);
            AddSkill(character, SkillType.Melee, 5);
            AddSkill(character, SkillType.Ranged, 10);
            AddSkill(character, SkillType.Survival, 15);
        }

        private static void AssignBerserkerSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Strength, 2);

            AddArmorProficiency(character, ArmorCategoryType.LightArmor);
            AddArmorProficiency(character, ArmorCategoryType.MediumArmor);
            AddArmorProficiency(character, ArmorCategoryType.HeavyArmor);

            AddWeaponProficiency(character, WeaponCategoryType.Axes);
            AddWeaponProficiency(character, WeaponCategoryType.Daggers);
            AddWeaponProficiency(character, WeaponCategoryType.ShortBow);
            AddWeaponProficiency(character, WeaponCategoryType.Swords);

            AddSkill(character, SkillType.DualWield, 5);
            AddSkill(character, SkillType.Fortitude, 15);
            AddSkill(character, SkillType.Melee, 15);
            AddSkill(character, SkillType.Resistance, 10);
            AddSkill(character, SkillType.Survival, 5);
        }

        private static void AssignCrusaderSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Strength, 1);
            character.ModifyAbilityBy(AbilityType.Constitution, 1);

            AddArmorProficiency(character, ArmorCategoryType.LightArmor);
            AddArmorProficiency(character, ArmorCategoryType.MediumArmor);
            AddArmorProficiency(character, ArmorCategoryType.HeavyArmor);
            AddArmorProficiency(character, ArmorCategoryType.Shields);

            AddWeaponProficiency(character, WeaponCategoryType.Daggers);
            AddWeaponProficiency(character, WeaponCategoryType.GreatSword);
            AddWeaponProficiency(character, WeaponCategoryType.ShortBow);
            AddWeaponProficiency(character, WeaponCategoryType.Swords);

            AddSkill(character, SkillType.Casting, 5);
            AddSkill(character, SkillType.Concentration, 5);
            AddSkill(character, SkillType.Fortitude, 10);
            AddSkill(character, SkillType.Leadership, 15);
            AddSkill(character, SkillType.Melee, 10);
            AddSkill(character, SkillType.Resistance, 5);
        }

        private static void AssignElementalistSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Intelligence, 2);

            AddArmorProficiency(character, ArmorCategoryType.LightArmor);
            AddArmorProficiency(character, ArmorCategoryType.Icons);

            AddWeaponProficiency(character, WeaponCategoryType.Daggers);
            AddWeaponProficiency(character, WeaponCategoryType.ShortBow);
            AddWeaponProficiency(character, WeaponCategoryType.Staves);

            AddSkill(character, SkillType.Casting, 20);
            AddSkill(character, SkillType.Concentration, 15);
            AddSkill(character, SkillType.Reflex, 5);
            AddSkill(character, SkillType.Resistance, 10);
        }

        private static void AssignMonkSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Dexterity, 1);
            character.ModifyAbilityBy(AbilityType.Strength, 1);

            AddArmorProficiency(character, ArmorCategoryType.LightArmor);
            AddArmorProficiency(character, ArmorCategoryType.MediumArmor);

            AddWeaponProficiency(character, WeaponCategoryType.Daggers);
            AddWeaponProficiency(character, WeaponCategoryType.Staves);
            AddWeaponProficiency(character, WeaponCategoryType.ShortBow);
            AddWeaponProficiency(character, WeaponCategoryType.Swords);

            AddSkill(character, SkillType.Casting, 5);
            AddSkill(character, SkillType.DualWield, 10);
            AddSkill(character, SkillType.Reflex, 15);
            AddSkill(character, SkillType.Perception, 5);
            AddSkill(character, SkillType.Melee, 15);
        }

        private static void AssignPriestSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Wisdom, 2);

            AddArmorProficiency(character, ArmorCategoryType.LightArmor);
            AddArmorProficiency(character, ArmorCategoryType.Icons);

            AddWeaponProficiency(character, WeaponCategoryType.Staves);
            AddWeaponProficiency(character, WeaponCategoryType.ShortBow);

            AddSkill(character, SkillType.Casting, 15);
            AddSkill(character, SkillType.Concentration, 10);
            AddSkill(character, SkillType.Fortitude, 5);
            AddSkill(character, SkillType.Leadership, 5);
            AddSkill(character, SkillType.Resistance, 15);
        }

        private static void AssignRangerSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Dexterity, 1);
            character.ModifyAbilityBy(AbilityType.Intelligence, 1);

            AddArmorProficiency(character, ArmorCategoryType.LightArmor);
            AddArmorProficiency(character, ArmorCategoryType.MediumArmor);
            AddArmorProficiency(character, ArmorCategoryType.Shields);

            AddWeaponProficiency(character, WeaponCategoryType.Axes);
            AddWeaponProficiency(character, WeaponCategoryType.CompoundBow);
            AddWeaponProficiency(character, WeaponCategoryType.CrossBow);
            AddWeaponProficiency(character, WeaponCategoryType.Daggers);
            AddWeaponProficiency(character, WeaponCategoryType.LongBow);
            AddWeaponProficiency(character, WeaponCategoryType.ShortBow);
            AddWeaponProficiency(character, WeaponCategoryType.Swords);

            AddSkill(character, SkillType.Block, 5);
            AddSkill(character, SkillType.Casting, 5);
            AddSkill(character, SkillType.Fortitude, 5);
            AddSkill(character, SkillType.Melee, 10);
            AddSkill(character, SkillType.Perception, 5);
            AddSkill(character, SkillType.Ranged, 15);
            AddSkill(character, SkillType.Survival, 5);
        }

        private static void AssignRogueSkills(CharacterBase character)
        {
            character.ModifyAbilityBy(AbilityType.Dexterity, 2);

            AddArmorProficiency(character, ArmorCategoryType.LightArmor);
            AddArmorProficiency(character, ArmorCategoryType.MediumArmor);

            AddWeaponProficiency(character, WeaponCategoryType.Daggers);
            AddWeaponProficiency(character, WeaponCategoryType.ShortBow);
            AddWeaponProficiency(character, WeaponCategoryType.Swords);

            AddSkill(character, SkillType.DualWield, 15);
            AddSkill(character, SkillType.Melee, 5);
            AddSkill(character, SkillType.Perception, 5);
            AddSkill(character, SkillType.Reflex, 10);
            AddSkill(character, SkillType.Thievery, 15);
        }

        private static void AddSkill(CharacterBase character, SkillType type, int value)
        {
            if (character.SkillExists(type))
            {
                var skill = character.GetSkill(type);
                character.SetSkillValue(type, skill.Value + value);
            }
            else
            {
                character.AddSkill(type, value);
            }
        }

        private static void AddArmorProficiency(CharacterBase character, ArmorCategoryType type)
        {
            if (character.ArmorProficiencies.Contains(type))
                return;
            character.ArmorProficiencies.Add(type);
        }

        private static void AddWeaponProficiency(CharacterBase character, WeaponCategoryType type)
        {
            if (character.WeaponProficiencies.Contains(type))
                return;
            character.WeaponProficiencies.Add(type);
        }
    }
}
