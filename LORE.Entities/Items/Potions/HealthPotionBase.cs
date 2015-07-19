using LORE.Entities.Characters;
using LORE.Entities.Misc;

namespace LORE.Entities.Items.Potions
{
    public class HealthPotionBase : PotionBase
    {
        public HealthPotionBase(string name, Money money, double weight, int value)
            : base(name, money, weight, value)
        {}

        public override void Consume(CharacterBase consumer)
        {
            consumer.CurrentHealth += PotionValue;
            if (consumer.CurrentHealth > consumer.MaximumHealth)
            {
                consumer.CurrentHealth = consumer.MaximumHealth;
            }
        }
    }
}
