namespace LORE.Entities.Items
{
    public class WeaponBase : ItemBase
    {
        public WeaponBase(
            string name, 
            int minimumDamage, int maximumDamage, 
            int hitModifier, int criticalModifier,
            int platinum = 0, int gold = 0, int silver = 0, int copper = 0
        ) : base(name, platinum, gold, silver, copper) {
            this.MinumumDamage = minimumDamage;
            this.MaximumDamage = maximumDamage;
            this.CriticalModifier = criticalModifier;
            this.HitModifier = hitModifier;
        }

        public int MinumumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public int HitModifier { get; set; }
        public int CriticalModifier { get; set; }
    }
}
