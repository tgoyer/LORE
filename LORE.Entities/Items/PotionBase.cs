using LORE.Entities.Characters;

namespace LORE.Entities.Items
{
    public abstract class PotionBase : ItemBase
    {
        public PotionBase(string name, int value, int platinum = 0, int gold = 0, int silver = 0, int copper = 0) : base(name, platinum, gold, silver, copper) {
            this.PotionValue = value;
        }
        public int PotionValue { get; set; }

        public abstract void Consume(CharacterBase consumer);
    }
}
