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
            var greaterHealthPotion = new HealthPotionBase("Greater Health Potion", new Money(silver: 20), 0.5, 20);
            var player = new PlayerBase(name)
            {
                CurrentHealth = 10,
                MaximumHealth = 40,
                Money = new Money()
            };
            player.Inventory.Add(greaterHealthPotion);
            
            while(loopAgain)
            {
                System.Console.WriteLine("Enter a command (am/i/m/x): ");
                var response = System.Console.ReadLine();
                
                switch(response) 
                {
                    case "am":
                        AddMoney(player, 150);
                        break;
                    case "i":
                        ShowInventory(player);
                        break;
                    case "m":
                        ShowMoney(player);
                        break;
                    case "x":
                    default:
                        loopAgain = false;
                        ShowExit();
                        break;
                }
            }
        }
        
        static void ShowExit()
        {
            System.Console.WriteLine("CYA!");
        }
        
        static void AddMoney(PlayerBase player, int amount)
        {
            player.Money.AddMoney(copper: amount);
        }

        static void ShowInventory(PlayerBase player)
        {
            foreach (var item in player.Inventory)
            {
                System.Console.WriteLine("    * {0} which is worth {1} coppers.", item.Name, item.Value);
                if (item is PotionBase)
                {
                    var p = (item as PotionBase);
                    System.Console.WriteLine("    *** This is a potion! {0} value.", p.PotionValue);
                }
                if (item is WeaponBase)
                {
                    var w = (item as WeaponBase);
                    System.Console.WriteLine("    *** This is a weapon! {0} base damage.", w.BaseDamage);
                }
                if (item is ArmorBase)
                {
                    var a = (item as ArmorBase);
                    System.Console.WriteLine("    *** This is armor! Stats: Name: {0}; Armor Value: {1}; Agility: {2}; Intelligence: {3}; Stamina: {4}; Strength: {5}; Wisdom: {6};", a.Name, a.ArmorValue, a.AgilityBoost, a.IntelligenceBoost, a.StaminaBoost, a.StrengthBoost, a.WisdomBoost);
                }
            }
        }
        
        static void ShowMoney(PlayerBase player)
        {
            System.Console.WriteLine(
                "{5} has {0} plat, {1} gold, {2} silver, {3} copper ({4} actual).",
                player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper, player.Money.Value, player.Name
            );
        }
    } 
}

