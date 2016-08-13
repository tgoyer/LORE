using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using LORE.Entities.Characters;
using LORE.Entities.Items;
using LORE.Entities.Mechanics;
using LORE.Entities.Misc;

namespace LORE.Entities.Mechanics.Start
{
    public class Start
    {
        public static void AskName(PlayerBase player)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            string Name = "";
            bool nameCreated = false;
            while (nameCreated == false)
            {
                System.Console.WriteLine("Type your name. (Minimum Length: 5)");
                System.Console.WriteLine("");
                Name = System.Console.ReadLine();
                if (Name.Length > 5 || Name.Length == 5)
                {
                    Name = myTI.ToTitleCase(Name);
                    nameCreated = true;
                }
                player.Name = Name;
                System.Console.Clear();
            }
        }
    }
}
