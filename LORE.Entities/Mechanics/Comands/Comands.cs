using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using LORE.Entities;
using LORE.Entities.Characters;
using LORE.Entities.Items;
using LORE.Entities.Mechanics;
using LORE.Entities.Misc;
using LORE.Entities.Items.Potions;

namespace LORE.Entities.Mechanics
{
    public class Comands
    {
        public static TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        
        public static void GiveMoney(PlayerBase player/**, Money money*/)
        {
            /**uint copper = 0;

            copper += Money.ConvertToCopper(platinum: 15);

            copper += Money.ConvertToCopper(gold: 20);

            copper += Money.ConvertToCopper(silver: 5);

            copper += 34;
            */
            bool doneMoney = false;
            while (doneMoney == false)
            {
                Console.Clear();
                Console.WriteLine("A: Plat");
                Console.WriteLine("");
                Console.WriteLine("B: Gold");
                Console.WriteLine("");
                Console.WriteLine("C: Silver");
                Console.WriteLine("");
                Console.WriteLine("D: Copper");
                Console.WriteLine("");
                ConsoleKeyInfo whichMoneyAdd = Console.ReadKey();
                Console.Clear();
                if (whichMoneyAdd.Key == ConsoleKey.A)
                {
                    Console.WriteLine("How much?");
                    Console.WriteLine("");
                    int number;
                    bool isNumberGivemoney = Int32.TryParse(Console.ReadLine(), out number);
                    if (isNumberGivemoney == true)
                    {
                        if (number > 0)
                        {
                            uint uNumberMoney = Convert.ToUInt32(number);
                            player.Money.AddMoney(platinum: uNumberMoney);
                            doneMoney = true;
                        }
                        Console.Clear();
                    }

                }
                if (whichMoneyAdd.Key == ConsoleKey.B)
                {
                    Console.WriteLine("How much?");
                    Console.WriteLine("");
                    int number;
                    bool isNumberGivemoney = Int32.TryParse(Console.ReadLine(), out number);
                    if (isNumberGivemoney == true)
                    {
                        if (number > 0)
                        {
                            uint uNumberMoney = Convert.ToUInt32(number);
                            player.Money.AddMoney(gold: uNumberMoney);
                            doneMoney = true;
                        }
                        Console.Clear();
                    }

                }
                if (whichMoneyAdd.Key == ConsoleKey.C)
                {
                    Console.WriteLine("How much?");
                    Console.WriteLine("");
                    int number;
                    bool isNumberGivemoney = Int32.TryParse(Console.ReadLine(), out number);
                    if (isNumberGivemoney == true)
                    {
                        if (number > 0)
                        {
                            uint uNumberMoney = Convert.ToUInt32(number);
                            player.Money.AddMoney(silver: uNumberMoney);
                            doneMoney = true;
                        }
                        Console.Clear();
                    }

                }
                if (whichMoneyAdd.Key == ConsoleKey.D)
                {
                    Console.WriteLine("How much?");
                    Console.WriteLine("");
                    int number;
                    bool isNumberGivemoney = Int32.TryParse(Console.ReadLine(), out number);
                    if (isNumberGivemoney == true)
                    {
                        if (number > 0)
                        {
                            uint uNumberMoney = Convert.ToUInt32(number);
                            player.Money.AddMoney(copper: uNumberMoney);
                            doneMoney = true;
                        }
                        Console.Clear();
                    }

                }
                if (player.Money._copper >= UInt32.MaxValue)
                {
                    player.Money._copper = uint.MaxValue;
                }
                Console.WriteLine("");
                Console.WriteLine("You now have {0} Platinum, {1} Gold, {2} Silver and {3} Copper!", player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper);
                Console.ReadLine();
            }
            //player.Money.AddMoney(copper: copper);
        }

        public static void HealMe(PlayerBase player)
        {
            string CurrentHealth = player.CurrentHealth.ToString();
            string MaximumHealth = player.MaximumHealth.ToString();
            Console.Clear();
            Console.WriteLine("{0} has {1} / {2} HP.", player.Name, CurrentHealth, MaximumHealth);
            Console.WriteLine("");
            Console.WriteLine("Heal for?");
            Console.WriteLine("");
            int healAmount;
            bool isNumberHeal = Int32.TryParse(Console.ReadLine(), out healAmount);
            if (isNumberHeal == true)
            {
                if (player.CurrentHealth + healAmount == player.MaximumHealth || player.CurrentHealth + healAmount > player.MaximumHealth)
                {
                    player.CurrentHealth = player.MaximumHealth;
                }
                else
                {
                    player.CurrentHealth = player.CurrentHealth + healAmount;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("{0} has {1} / {2} HP.", player.Name, player.CurrentHealth, player.MaximumHealth);
            Console.ReadLine();
        }

        public static void ShowInventory(PlayerBase player)
        {
            foreach (var item in player.Inventory)
            {
                System.Console.WriteLine("{0} which is worth {1} coppers.", item.Name, item.Value);
                System.Console.WriteLine("");
                if (item is PotionBase)
                {
                    var p = (item as PotionBase);
                    System.Console.WriteLine("    *** This is a potion! {0} value.", p.PotionValue);
                    System.Console.WriteLine("");
                }
                if (item is WeaponBase)
                {
                    var w = (item as WeaponBase);
                    System.Console.WriteLine("    *** This is a weapon! {0} base damage.", w.BaseDamage);
                    System.Console.WriteLine("");
                }
                if (item is ArmorBase)
                {
                    var a = (item as ArmorBase);
                    System.Console.WriteLine("    *** This is armor! Stats: Name: {0}; Armor Value: {1}; Agility: {2}; Intelligence: {3}; Stamina: {4}; Strength: {5}; Wisdom: {6};", a.Name, a.ArmorValue, a.AgilityBoost, a.IntelligenceBoost, a.StaminaBoost, a.StrengthBoost, a.WisdomBoost);
                    System.Console.WriteLine("");
                }
            }
        }
       
        public static void Buy(PlayerBase player)
        {

        }
    }
}
