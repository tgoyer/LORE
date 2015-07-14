using LORE.Common.Enums;

namespace LORE.Entities.Items
{
    public class ArmorBase : ItemBase
    {
        public ArmorBase(
            string name,
            ArmorTypes type,
            int armorValue,
            int staminaBoost,
            int strengthBoost,
            int agilityBoost,
            int intelligenceBoost,
            int wisdomBoost,
            int platinum = 0,
            int gold = 0,
            int silver = 0,
            int copper = 0
            )
            : base(name, platinum, gold, silver, copper)
        {
            Type = type;
            ArmorValue = armorValue;
            StaminaBoost = staminaBoost;
            StrengthBoost = strengthBoost;
            AgilityBoost = agilityBoost;
            IntelligenceBoost = intelligenceBoost;
            WisdomBoost = wisdomBoost;

        }

        public ArmorTypes Type { get; set; }
        public int ArmorValue { get; set; }
        public int StaminaBoost { get; set; }
        public int StrengthBoost { get; set; }
        public int AgilityBoost { get; set; }
        public int IntelligenceBoost { get; set; }
        public int WisdomBoost { get; set; }
    }
}

