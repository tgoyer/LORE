using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public class ItemBase
    {
        public ItemBase(string name, Money money)
        {
            Name = name;
            Value = money.Value;
        }
        
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
