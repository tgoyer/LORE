using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public abstract class WeaponBase : ItemBase
    {
        public WeaponBase(string name, Money money, int baseDamage, int maximumDamage, int hitModifier, int criticalModifier) : base(name, money) {
            BaseDamage = baseDamage;
            CriticalModifier = criticalModifier;
            HitModifier = hitModifier;
        }

        public int BaseDamage { get; set; }
        public int HitModifier { get; set; }
        public int CriticalModifier { get; set; }

        public abstract int Attack();
    }
}
