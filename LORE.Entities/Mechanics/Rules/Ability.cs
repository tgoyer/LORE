namespace LORE.Entities.Mechanics.Rules
{
    public enum AbilityType
    {
        Dexterity,
        Wisdom,
        Strength,
        Constitution,
        Charisma,
        Intelligence
    }

    public class Ability
    {
        public Ability(AbilityType type, int value)
        {
            Type = type;
            Value = value;
        }

        public AbilityType Type { get; set; }
        public int Value { get; set; }
    }
}
