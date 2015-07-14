using LORE.Entities.Characters;

namespace LORE.Console.Characters.Mobs.Trolls
{
    public class WarriorTroll : MobBase
    {
        public WarriorTroll() : base("Warrior Troll") {
            this.IsAggressive = true;
        }
    }
}
