using System;
using LORE.Entities.Characters;

namespace LORE.Entities.Mechanics.Start
{
    public class Start
    {
        public static void CreatePlayer(PlayerBase player)
        {
            bool userCreated = false;
            while (userCreated == false)
            {
                Console.Clear();
                Console.WriteLine("Enter Name (5 - 15 Characters)");
                Console.WriteLine("");
                string Name = null;
                Name = Console.ReadLine();
                if (Name.Length >= 5 && Name.Length > 0 && Name.Length <= 15)
                {
                    bool nameConfirmed = false;
                    while (nameConfirmed == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Please Confirm! Type: {0} Or press Esc to cancel.", Name);
                        Console.WriteLine("");
                        ConsoleKeyInfo info = Console.ReadKey();
                        if (info.Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            break;
                        }
                        var ans = Console.ReadLine();
                        if (Name == info.Key + ans)
                        {
                            userCreated = true;
                            player.Name = Name;
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                    }
                }
                Console.Clear();

            }
        }


        public static void ShowMoney(PlayerBase player)
        {
            System.Console.WriteLine(
               "{4} has {0} plat, {1} gold, {2} silver, {3} copper.", player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper, player.Name
            );
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}