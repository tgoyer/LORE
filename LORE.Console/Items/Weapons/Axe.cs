using LORE.Entities.Items;

namespace LORE.Console.Items.Weapons
{
    public class Axe : WeaponBase
    {
        public Axe(string name, 
            int minimumDamage, int maximumDamage, 
            int hitModifier, int criticalModifier,
            int platinum = 0, int gold = 0, int silver = 0, int copper = 0) 
            : base (name, minimumDamage, maximumDamage, hitModifier, criticalModifier, platinum, gold, silver, copper)
        {
        }
    }
}
