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

            System.Console.WriteLine("He disapears into the forest.");
            
            System.Console.WriteLine("You see a man walking in circles in the forest. He looks scared. What should you do?");
            System.Console.WriteLine("1) Go up to him.");
            System.Console.WriteLine("2) Try to sneak up on him (rouge class)");
            System.Console.WriteLine("3) Walk away.");

            var response = System.Console.ReadLine();
            if (response == "1" || response == "2" || response == "3")
            {
                if (response == "1")
                {
                    System.Console.WriteLine("The man sees you.");
                    System.Console.WriteLine("Man: Hey, I need your help! My wife is in grave danger and I can't save her! Will you help me?");
                    System.Console.WriteLine("1) Yes!");
                    System.Console.WriteLine("2) Naw.");
                    System.Console.ReadLine();
                    response = System.Console.ReadLine();
                    if (response == "1" || response == "2")

                        if (response == "1")
                        {
                            System.Console.WriteLine("Oh thank you! Ill pay you 100 gold for your troubles.");
                        }
                        if (response == "2")
                        {
                            System.Console.Clear();
                        }
                    }
                }
            else
            {
                System.Console.Clear();
            }
        }
   } 
}


