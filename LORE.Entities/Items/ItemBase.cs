using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public class ItemBase
    {
        public ItemBase(string name, int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
        {
            Name = name;
            Value = Money.ConvertToCopper(platinum, gold, silver, copper);
        }
        
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
