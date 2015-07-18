using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public class WeaponBase : ItemBase
    {
        public WeaponBase(string name, Money money, int minimumDamage, int maximumDamage, int hitModifier, int criticalModifier) : base(name, money) {
            MinumumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            CriticalModifier = criticalModifier;
            HitModifier = hitModifier;
        }

        public int MinumumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int HitModifier { get; set; }
        public int CriticalModifier { get; set; }
    }
}
