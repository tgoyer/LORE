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


namespace LORE.Entities.Mechanics
{
    public class Comands
    {
        public static TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        
        public static void GiveMoney(PlayerBase player)
        {
            bool doneMoney = false;
            while (doneMoney == false)
            {
                Console.Clear();
                Console.WriteLine("Plat, Gold, Silver or Copper?");
                Console.WriteLine("");
                var whichMoneyAdd = myTI.ToTitleCase(Console.ReadLine());
                if (whichMoneyAdd == "Plat")
                {
                    Console.WriteLine("");
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
                            Console.WriteLine("");
                            Console.WriteLine("You now have {0} Platinum, {1} Gold, {2} Silver and {3} Copper!", player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper);
                            Console.ReadLine();
                            doneMoney = true;
                        }
                    }
                }
            }
        }

        public static void HealMe(PlayerBase player)
        {
            Console.Clear();
            Console.WriteLine("{} has {} / {} HP.");
            Console.WriteLine("");
            Console.WriteLine("Heal for?");
            int healAmount;
            bool isNumberHeal = Int32.TryParse(Console.ReadLine(), out healAmount);
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
        public static void ShowCharacter(PlayerBase player)
        {
            
        }
    }
}
