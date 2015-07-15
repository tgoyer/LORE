using LORE.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORE.Console.Characters.Mobs.Mobs
{
    class Goblin : MobBase
    {
        public Goblin() : base("Goblin")
        {
            this.IsAggressive = false;
        }
    }
}
