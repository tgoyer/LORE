using LORE.Common.Enums;
using LORE.Entities.Items;

namespace LORE.Console.Items.Armor
{
    class Chestplate : ArmorBase
    {
        public Chestplate(string name,
            int armorValue, int staminaBoost,
            int strengthBoost, int wisdomBoost,
            int intelligenceBoost, int agilityBoost,
            int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
            : base(name, ArmorTypes.Chest, armorValue, staminaBoost, strengthBoost, agilityBoost, intelligenceBoost, wisdomBoost, platinum, gold, silver, copper)
        {

        }
    }
}
