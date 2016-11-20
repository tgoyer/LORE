using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public class ItemBase
    {
        public ItemBase(string name, Money money, double weight)
        {
            Name = name;
            Value = money.Value;
            Weight = weight;
        }
        
        public string Name { get; set; }
        public uint Value { get; set; }
        public double Weight { get; set; }
    }
}
