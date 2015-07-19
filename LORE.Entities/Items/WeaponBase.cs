using System.Collections.Generic;
using LORE.Entities.Characters;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public abstract class WeaponBase : EquipmentBase
    {
        public WeaponBase(string name, Money money, double weight, EquipmentCategory category, List<EquipmentType> types, int baseDamage, int hitModifier, int criticalModifier) : base(name, money, weight, category, types) {
            BaseDamage = baseDamage;
            CriticalModifier = criticalModifier;
            HitModifier = hitModifier;
        }

        public int BaseDamage { get; set; }
        public int HitModifier { get; set; }
        public int CriticalModifier { get; set; }

        public abstract AttackResult Attack(CharacterBase attacker, CharacterBase defender);
    }
}
