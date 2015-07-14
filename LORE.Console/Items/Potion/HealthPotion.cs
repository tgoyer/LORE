using LORE.Entities.Characters;
using LORE.Entities.Items;

namespace Game.Items.Potion
{
    public class HealthPotion : PotionBase
    {
        public HealthPotion(string name, int value, int platinum = 0, int gold = 0, int silver = 0, int copper = 0)
            : base(name, value, platinum, gold, silver, copper)
        {}

        public override void Consume(CharacterBase consumer)
        {
            consumer.CurrentHealth += this.PotionValue;
            if (consumer.CurrentHealth > consumer.MaximumHealth) {
                consumer.CurrentHealth = consumer.MaximumHealth;
            }
        }
    }
}
