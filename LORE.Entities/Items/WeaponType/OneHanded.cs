using System;
using System.Collections.Generic;
using LORE.Entities.Characters;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;

namespace LORE.Entities.Items.WeaponType
{
    public class OneHandedSword : WeaponBase
    {
        public OneHandedSword(string name, Money money, double weight, int baseDamage, int hitModifier, int criticalModifier) : base(
            name, money, weight, EquipmentCategory.Swords, 
            new List<EquipmentType> { EquipmentType.MainHand, EquipmentType.SecondaryHand }, 
            baseDamage, hitModifier, criticalModifier
        ) { }

        public override AttackResult Attack(CharacterBase attacker, CharacterBase defender)
        {
            throw new NotImplementedException();
        }
    }
}
