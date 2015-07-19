namespace LORE.Entities.Mechanics.Rules
{
    public enum SkillType
    {
        Block,
        Casting,
        Concentration,
        DualWield,
        Fortitude,
        LanguageCommon,
        LanguageDwarf,
        LanguageElf,
        LanguageGoblin,
        LanguageOrc,
        Leadership,
        Melee,
        Perception,
        Ranged,
        Reflex,
        Resistance,
        Survival,
        Thievery
    }

    public class Skill
    {
        public Skill(SkillType type, AbilityType modifier, int value)
        {
            Type = type;
            Value = value;
            SkillModifier = modifier;
        }

        public SkillType Type { get; set; }
        public AbilityType SkillModifier { get; set; }
        public int Value { get; set; }
    }
}
