using LORE.Entities.Characters;
using LORE.Entities.Items;
using LORE.Entities.Items.Potions;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;
using LORE.MiddeTier;
using LORE.MiddeTier.Rules;
using LORE.Console;

namespace LORE.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loopAgain = true;
            
            while(loopAgain)
            {
                System.Console.WriteLine("Enter a command: ");
                var response = System.Console.ReadLine();
                
                switch(response) 
                {
                    case "i":
                        ShowInventory();
                    case "m":
                        ShowMoney();
                    case "x":
                        loopAgain = false;
                }
            }
        }
    } 
}

