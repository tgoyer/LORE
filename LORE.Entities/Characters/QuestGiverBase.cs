using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LORE.Entities.Characters
{
    public abstract class QuestGiverBase : CharacterBase
    {
        public QuestGiverBase() : base() { }
        
        public bool IsAvailable { get; set; }
    }
}
