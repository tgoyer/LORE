using System.Collections.Generic;
using LORE.Entities.Items;
using LORE.Entities.Misc;

namespace LORE.Entities.Characters
{
    public abstract class CharacterBase
    {
        public CharacterBase() {
            this.Money = new Money();
            this.Inventory = new List<ItemBase>();
        }

        public CharacterBase(string name) : this() {
            this.Name = name;
        }

        public string Name { get; set; }
        public int CurrentHealth { get; set; }
        public int MaximumHealth { get; set; }
        public int Level { get; set; }
        public List<ItemBase> Inventory { get; set; }
        public Money Money { get; set; }
    }
}