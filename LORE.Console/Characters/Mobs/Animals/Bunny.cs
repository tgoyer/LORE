using LORE.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORE.Console.Characters.Mobs.Animals
{
    class Bunny : MobBase
    {
        public Bunny()
        {
            this.Name = "Bunny Rabit";
            this.IsAggressive = false;
        }
    }
}
