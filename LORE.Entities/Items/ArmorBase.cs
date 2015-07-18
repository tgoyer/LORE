using LORE.Common.Enums;
using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public class ArmorBase : ItemBase
    {
        public ArmorBase(
            string name, Money money, 
            ArmorTypes type, int armorValue, int staminaBoost, int strengthBoost, int agilityBoost, int intelligenceBoost, int wisdomBoost
        ) : base(name, money)
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

