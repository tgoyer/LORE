using System.Collections.Generic;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public abstract class WeaponBase : ItemBase
    {
        public WeaponBase(string name, Money money, int baseDamage, int hitModifier, int criticalModifier) : base(name, money) {
            BaseDamage = baseDamage;
            CriticalModifier = criticalModifier;
            HitModifier = hitModifier;
            ClassRestrictions = new List<ClassType>();
            RaceRestrictions = new List<RaceType>();
        }

        public List<ClassType> ClassRestrictions { get; private set; }
        public List<RaceType> RaceRestrictions { get; private set; }
        public int BaseDamage { get; set; }
        public int HitModifier { get; set; }
        public int CriticalModifier { get; set; }

        public abstract AttackResult Attack();

        public void SetClassRestriction(ClassType type)
        {
            if (!ClassRestrictions.Contains(type))
            {
                ClassRestrictions.Add(type);
            }
        }
        public void SetClassRestriction(List<ClassType> types)
        {
            foreach (var type in types)
            {
                SetClassRestriction(type);
            }
        }

        public void SetRaceRestriction(RaceType type)
        {
            if (!RaceRestrictions.Contains(type))
            {
                RaceRestrictions.Add(type);
            }
        }
        public void SetRaceRestriction(List<RaceType> types)
        {
            foreach (var type in types)
            {
                SetRaceRestriction(type);
            }
        }
    }
}
