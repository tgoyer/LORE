using LORE.Entities.Characters;
using LORE.Entities.Misc;

namespace LORE.Entities.Items
{
    public abstract class PotionBase : ItemBase
    {
        public PotionBase(string name, Money money, double weight, int value) : base(name, money, weight)
        {
            PotionValue = value;
        }

        public int PotionValue { get; set; }

        public abstract void Consume(CharacterBase consumer);
    }
}
