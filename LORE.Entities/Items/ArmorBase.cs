using System.Collections.Generic;
using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public abstract class ArmorBase : EquipmentBase
    {
        public ArmorBase(
            string name, Money money, EquipmentCategory category, List<EquipmentType> type, double weight,
            int armorValue, int staminaBoost, int strengthBoost, int agilityBoost, int intelligenceBoost, int wisdomBoost
        ) : base(name, money, weight, category, type)
        {
            ArmorValue = armorValue;
            StaminaBoost = staminaBoost;
            StrengthBoost = strengthBoost;
            AgilityBoost = agilityBoost;
            IntelligenceBoost = intelligenceBoost;
            WisdomBoost = wisdomBoost;
        }

        public int ArmorValue { get; set; }
        public int StaminaBoost { get; set; }
        public int StrengthBoost { get; set; }
        public int AgilityBoost { get; set; }
        public int IntelligenceBoost { get; set; }
        public int WisdomBoost { get; set; }
    }
}

