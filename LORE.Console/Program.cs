using System;
using Game.Items.Potion;
using LORE.Console.Characters;
using LORE.Console.Items.Armor;
using LORE.Console.Items.Weapons;
using LORE.Entities.Items;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Blargity De Blargplop");
            player.CurrentHealth = 10;
            player.MaximumHealth = 40;
            player.Money.AddMoney(platinum: 2, copper: 15);
            player.Money.SubtractMoney(silver: 15);

            Axe fieryAxeOfDoom = new Axe("Fiery Axe Of Doom", 10, 25, 2, 6, gold: 20);
            Axe fieryAxeOfLame = new Axe("Fiery Axe Of Lame", 1, 2, 0, 0, copper: 2);
            HealthPotion greaterHealthPotion = new HealthPotion("Greater Health Potion", 20, silver: 20);
            HealthPotion lesserHealthPotion = new HealthPotion("Lesser Health Potion", 10, copper: 20);
            Chestplate iornChestplate = new Chestplate("Iorn Chestplate", 10, 5, 1, 8, 0, 0, 1, 1, 50, 0);
            
            player.Inventory.Add(fieryAxeOfDoom);
            player.Inventory.Add(fieryAxeOfLame);
            player.Inventory.Add(greaterHealthPotion);
            player.Inventory.Add(lesserHealthPotion);
            player.Inventory.Add(iornChestplate);
            
            Console.WriteLine(" Player's HP = {0}/{1}.", player.CurrentHealth, player.MaximumHealth);
            var potion = (HealthPotion)player.Inventory.Find(i => i.Name == "Greater Health Potion");
            potion.Consume(player);
            player.Inventory.Remove(potion);
            Console.WriteLine(" Player's HP = {0}/{1}.", player.CurrentHealth, player.MaximumHealth);

            Console.WriteLine(
                "{5} has {0} plat, {1} gold, {2} silver, {3} copper ({4} actual).", 
                player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper, player.Money.Value, player.Name
            );
            Console.WriteLine("Inventory:");

            foreach(ItemBase item in player.Inventory)
            {
                Console.WriteLine("    * {0} which is worth {1} coppers.", item.Name, item.Value);
                if (item is PotionBase)
                {
                    Console.WriteLine("    *** This is a potion! {0} value.", ((PotionBase)item).PotionValue);
                }
                if (item is WeaponBase)
                {
                    Console.WriteLine("    *** This is a weapon! {0} max damage.", ((WeaponBase)item).MaximumDamage);
                }
                if (item is ArmorBase)
                {
                    ArmorBase armor = (item as ArmorBase);
                    Console.WriteLine("    *** This is armor! Stats: Name: {0}; Armor Value: {1}; Agility: {2}; Intelligence: {3}; Stamina: {4}; Strength: {5}; Wisdom: {6};", armor.Name, armor.ArmorValue, armor.AgilityBoost, armor.IntelligenceBoost, armor.StaminaBoost, armor.StrengthBoost, armor.WisdomBoost);
                }
            }

            Console.ReadLine();
        }
    }
}
