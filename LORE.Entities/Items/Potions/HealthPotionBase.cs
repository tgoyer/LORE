using LORE.Entities.Characters;
using LORE.Entities.Misc;

namespace LORE.Entities.Items.Potions
{
    public class HealthPotionBase : PotionBase
    {
        public HealthPotionBase(string name, Money money, int value) : base(name, money, value)
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
