using System.Collections.Generic;
using System.Linq;
using LORE.Entities.Items;
using LORE.Entities.Misc;

namespace LORE.Entities.Mechanics.Inventory
{
    public class BagBase : ItemBase
    {
        private readonly int maxCapacity;

        public BagBase(string name, Money money, double weight, int maxCapacity)
            : base(name, money, weight)
        {
            Contents = new List<ItemBase>();
            this.maxCapacity = maxCapacity;
        }

        public List<ItemBase> Contents { get; private set; }

        public void AddItem(ItemBase item)
        {
            if (Contents.Count < maxCapacity)
            {
                Contents.Add(item);
            }
        }

        public double GetTotalWeight()
        {
            return Contents.Sum(item => item.Weight);
        }
    }
}
