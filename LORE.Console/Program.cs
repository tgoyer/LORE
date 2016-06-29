using LORE.Entities.Characters;
using LORE.Entities.Items;
using LORE.Entities.Items.Potions;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;
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
            var greaterHealthPotion = new HealthPotionBase("Greater Health Potion", new Money(silver: 20), 0.5, 20);
            var lesserHealthPotion = new HealthPotionBase("Lesser Health Potion", new Money(copper: 20), 0.5, 10);
            //var iornChestplate = new ArmorBase("Iorn Chestplate", new Money(platinum: 1, gold: 1, silver: 50), EquipmentType.Chest, 10, 5, 1, 8, 0, 0);
            #endregion Item Creation

            #region Player Creation
            #region Create Player
            var name = "";
            while (name == "") 
            {
                System.Console.WriteLine("Type your name.");
                name = System.Console.ReadLine();
                System.Console.Clear();
            }

            System.Console.Clear();
            var player = new PlayerBase(name)
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
            var selectedRace = "555456456456456555";
            while (selectedRace != "1" && selectedRace != "2" && selectedRace != "3" && selectedRace != "4")
            {
                System.Console.WriteLine("Select your race.");
                System.Console.WriteLine("1) Elf    2) Dwarf     3) Halfling    3) Human    4) Orc");
                selectedRace = System.Console.ReadLine();
                if (selectedRace == "1" || selectedRace == "2" || selectedRace == "3" || selectedRace == "4")
                {
                    if (selectedRace == "1")
                    {
                        player.AssignRace(RaceType.Elf);
                    };

                    if (selectedRace == "2")
                    {
                        player.AssignRace(RaceType.Dwarf);
                    };

                    if (selectedRace == "3")
                    {
                        player.AssignRace(RaceType.Halfling);
                    }

                    if (selectedRace == "4")
                    {
                        player.AssignRace(RaceType.Orc);
                    };
                };
                System.Console.Clear();
            };
            System.Console.Clear();

            var chosenClass = "100";
            while (chosenClass != "1" && chosenClass != "2" && chosenClass != "3" && chosenClass != "4" && chosenClass != "5" && chosenClass != "6" && chosenClass != "7" && chosenClass != "8")
            {
                System.Console.WriteLine("Choose a Class");
                System.Console.WriteLine("1) Bard   2) Berserker    3) Crusader     4) Elementalist     5) Monk     6) Priest     7) Ranger     8) Rouge");
                chosenClass = System.Console.ReadLine();
                if (chosenClass == "1")
                {
                    player.AssignClass(ClassType.Bard);
                }

                if (chosenClass == "2")
                {
                    player.AssignClass(ClassType.Berserker);
                }

                if (chosenClass == "3")
                {
                    player.AssignClass(ClassType.Crusader);
                }

                if (chosenClass == "4")
                {
                    player.AssignClass(ClassType.Elementalist);
                }

                if (chosenClass == "5")
                {
                    player.AssignClass(ClassType.Monk);
                }

                if (chosenClass == "6")
                {
                    player.AssignClass(ClassType.Priest);
                }

                if (chosenClass == "7")
                {
                    player.AssignClass(ClassType.Ranger);
                }

                if (chosenClass == "8")
                {
                    player.AssignClass(ClassType.Rogue);
                }
                System.Console.Clear();
            };
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
            //player.Inventory.Add(iornChestplate);
            #endregion Populate Player Inventory

            #region Display Generated Values
            #region Show Player Race/Class
            System.Console.WriteLine("{2} is a {0} {1}.", player.Race.ToString(), player.Class.ToString(), name);
            #endregion Show Player Race/Class


            #region Show Player HPs
            System.Console.WriteLine(" {2}'s HP = {0}/{1}.", player.CurrentHealth, player.MaximumHealth, name);
            var potion = (HealthPotionBase)player.Inventory.Find(i => i.Name == "Greater Health Potion");
            potion.Consume(player);
            player.Inventory.Remove(potion);
            System.Console.WriteLine(" {2}'s HP = {0}/{1}.", player.CurrentHealth, player.MaximumHealth, name);
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
            System.Console.WriteLine("");
            System.Console.WriteLine(" Player's Skills are: ");
            foreach (var s in player.Skills)
            {
                System.Console.WriteLine("      {0}: {1}. (Actual: {2})", s.Type.ToString(), player.GetSkillScore(s.Type), s.Value);
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

            System.Console.WriteLine("Press Enter");
            System.Console.ReadLine();
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Command List:     1) GiveMoney   2) HealMe");
                string comand = "null";
                while (comand != "GiveMoney" || comand != "HealMe") 
                {
                    comand = System.Console.ReadLine();
                    
                    if (comand == "GiveMoney")
                    {
                        string amountAdd = "";
                        System.Console.WriteLine("You have {0} Plat, {1} Gold, {2} Silver, and {3} Copper.", player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper);
                        System.Console.WriteLine("How Much?");
                        amountAdd = System.Console.ReadLine();
                        int amountAddint = System.Convert.ToInt32(amountAdd);
                        player.Money.AddMoney(copper: amountAddint);
                        System.Console.WriteLine("You have {0} Plat, {1} Gold, {2} Silver, and {3} Copper now!", player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper);
                        System.Console.ReadLine();
                    };

                    if (comand == "HealMe")
                    {
                        string amountHeal = "";
                        System.Console.WriteLine("You have {0}/{1} HP.", player.CurrentHealth, player.MaximumHealth);
                        System.Console.ReadLine();
                        System.Console.WriteLine("Heal for?");
                        amountHeal = System.Console.ReadLine();
                        int amountHealint = System.Convert.ToInt32(amountHeal);
                        var hackHP = new HealthPotionBase("Greater Health Potion", new Money(copper: 0),0 , amountHealint);

                    };
                };
            };
            #endregion Test Console App

        }
    }
}
