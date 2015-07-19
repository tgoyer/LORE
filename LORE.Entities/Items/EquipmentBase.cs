using System.Collections.Generic;
using LORE.Entities.Characters;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public abstract class EquipmentBase : ItemBase
    {
        public EquipmentBase(string name, Money money, double weight, EquipmentCategory category, List<EquipmentType> types) : base(name, money, weight)
        {
            ClassRestrictions = new List<ClassType>();
            RaceRestrictions = new List<RaceType>();
            Category = category;
            Types = types;
        }

        public EquipmentCategory Category { get; private set; }
        public List<EquipmentType> Types { get; private set; }

        public List<ClassType> ClassRestrictions { get; private set; }
        public List<RaceType> RaceRestrictions { get; private set; }

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

        public bool CanEquip(CharacterBase character, EquipmentType location)
        {
            return (character.Proficiencies.Contains(Category) && Types.Contains(location));
        }
    }
}
