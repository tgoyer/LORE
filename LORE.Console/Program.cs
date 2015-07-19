using LORE.Common.Enums;
using LORE.Entities.Characters;
using LORE.Entities.Items;
using LORE.Entities.Items.Potions;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;
using LORE.MiddeTier;
using LORE.MiddeTier.Rules;

namespace LORE.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test Console App
            var ruleSet = new AbilityScoreRules();

            #region Item Creation
            //var fieryAxeOfDoom = new WeaponBase("Fiery Axe Of Doom", new Money(gold: 20), 10, 25, 2, 6);
            //var fieryAxeOfLame = new WeaponBase("Fiery Axe Of Lame", new Money(copper: 2), 1, 2, 0, 0);
            var greaterHealthPotion = new HealthPotionBase("Greater Health Potion", new Money(silver: 20), 20);
            var lesserHealthPotion = new HealthPotionBase("Lesser Health Potion", new Money(copper: 20), 10);
            var iornChestplate = new ArmorBase("Iorn Chestplate", new Money(platinum: 1, gold: 1, silver: 50), ArmorType.Chest, 10, 5, 1, 8, 0, 0);
            #endregion Item Creation

            #region Player Creation
            #region Create Player
            var player = new PlayerBase("Elfman")
            {
                CurrentHealth = 10,
                MaximumHealth = 40,
                Money = new Money()
            };
            #endregion Create Player

            #region Roll Player Stats
            // Setup all abilites.  Assign base of 10 to each.
            player.AddAbility(AbilityType.Charisma);
            player.AddAbility(AbilityType.Constitution);
            player.AddAbility(AbilityType.Dexterity);
            player.AddAbility(AbilityType.Intelligence);
            player.AddAbility(AbilityType.Strength);
            player.AddAbility(AbilityType.Wisdom);

            // Modify abilites based on race and class.  Assign skills.
            player.AssignRace(RaceType.Halfling);
            player.AssignClass(ClassType.Rogue);
            #endregion Roll Player Stats

            #region Player Starter Cash
            player.Money.AddMoney(platinum: 2, copper: 15);
            player.Money.SubtractMoney(silver: 15);
            #endregion Player Starter Cash
            #endregion Player Creation

            #region Populate Player Inventory
            //player.Inventory.Add(fieryAxeOfDoom);
            //player.Inventory.Add(fieryAxeOfLame);
            player.Inventory.Add(greaterHealthPotion);
            player.Inventory.Add(lesserHealthPotion);
            player.Inventory.Add(iornChestplate);
            #endregion Populate Player Inventory

            #region Display Generated Values
            #region Show Player Race/Class
            System.Console.WriteLine("Player is a {0} {1}.", player.Race.ToString(), player.Class.ToString());
            #endregion Show Player Race/Class


            #region Show Player HPs
            System.Console.WriteLine(" Player's HP = {0}/{1}.", player.CurrentHealth, player.MaximumHealth);
            var potion = (HealthPotionBase)player.Inventory.Find(i => i.Name == "Greater Health Potion");
            potion.Consume(player);
            player.Inventory.Remove(potion);
            System.Console.WriteLine(" Player's HP = {0}/{1}.", player.CurrentHealth, player.MaximumHealth);
            #endregion Show Player HPs

            #region Show Player Stats
            System.Console.WriteLine("");
            System.Console.WriteLine(" Player's Abilities are: ");
            foreach (var a in player.Abilities)
            {
                var rule = ruleSet.GetRuleByStatValue(a.Value);
                System.Console.WriteLine("      {0}: {1} which is {2} ({3}).", a.Type.ToString(), a.Value, rule.Name, rule.Modifier);
            }
            System.Console.WriteLine("");
            #endregion Show Player Stats

            #region Show Player Cash
            System.Console.WriteLine(
                "{5} has {0} plat, {1} gold, {2} silver, {3} copper ({4} actual).", 
                player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper, player.Money.Value, player.Name
            );
            System.Console.WriteLine("Inventory:");
            #endregion Show Player Cash

            #region Show Player Inventory
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
            #endregion Show Player Inventory
            #endregion Display Generated Values

            System.Console.ReadLine();
            #endregion Test Console App
        }
    }
}
