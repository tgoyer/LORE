using System.Globalization;
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
            var greaterHealthPotion = new HealthPotionBase("Greater Health Potion", new Money(silver: 20), 0.5, 20);
            var lesserHealthPotion = new HealthPotionBase("Lesser Health Potion", new Money(copper: 20), 0.5, 10);
            // var iornChestplate = new ArmorBase("Iorn Chestplate", new Money(platinum: 1, gold: 1, silver: 50), EquipmentType.Chest, 10, 5, 1, 8, 0, 0, 0, 0);
            #endregion Item Creation

            #region Player Creation
            #region Create Player
            string name = ""; 
            bool nameCreated = false;
            while (nameCreated == false) 
            {
                System.Console.WriteLine("Type your name. (Minimum Length: 5)");
                name = System.Console.ReadLine();
                if (name.Length > 5 || name.Length == 5)
                {
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    name = myTI.ToTitleCase(name);
                    nameCreated = true;
                }
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
            bool raceSelected = false;
            while (raceSelected == false)
            {
                System.Console.WriteLine("Select your race.");
                System.Console.WriteLine("1) Elf    2) Dwarf     3) Halfling    4) Human    5) Orc");
                var selectedRace = System.Console.ReadLine();
                {
                    if (selectedRace == "1")
                    {
                        player.AssignRace(RaceType.Elf);
                        raceSelected = true;
                    };

                    if (selectedRace == "2")
                    {
                        player.AssignRace(RaceType.Dwarf);
                        raceSelected = true;
                    };

                    if (selectedRace == "3")
                    {
                        player.AssignRace(RaceType.Halfling);
                        raceSelected = true;
                    }

                    if (selectedRace == "4")
                    {
                        player.AssignRace(RaceType.Human);
                        raceSelected = true;
                    }

                    if (selectedRace == "5")
                    {
                        player.AssignRace(RaceType.Orc);
                        raceSelected = true;
                    };
                };
                System.Console.Clear();
            };
            System.Console.Clear();

            bool classChoosen = false;
            while (classChoosen == false)
            {
                System.Console.WriteLine("Choose a Class");
                System.Console.WriteLine("1) Bard   2) Berserker    3) Crusader     4) Elementalist     5) Monk           6) Priest     7) Ranger     8) Rouge");
                var chosenClass = System.Console.ReadLine();
                if (chosenClass == "1")
                {
                    player.AssignClass(ClassType.Bard);
                    classChoosen = true;
                }

                if (chosenClass == "2")
                {
                    player.AssignClass(ClassType.Berserker);
                    classChoosen = true;
                }

                if (chosenClass == "3")
                {
                    player.AssignClass(ClassType.Crusader);
                    classChoosen = true;
                }

                if (chosenClass == "4")
                {
                    player.AssignClass(ClassType.Elementalist);
                    classChoosen = true;
                }

                if (chosenClass == "5")
                {
                    player.AssignClass(ClassType.Monk);
                    classChoosen = true;
                }

                if (chosenClass == "6")
                {
                    player.AssignClass(ClassType.Priest);
                    classChoosen = true;
                }

                if (chosenClass == "7")
                {
                    player.AssignClass(ClassType.Ranger);
                    classChoosen = true;
                }

                if (chosenClass == "8")
                {
                    player.AssignClass(ClassType.Rogue);
                    classChoosen = true;
                }
                System.Console.Clear();
            };
            #endregion Roll Player Stats

            #region Player Starter Cash
            player.Money.AddMoney(platinum: 2, copper: 15);
            #endregion Player Starter Cash
            #endregion Player Creation
            
            #region Populate Player Inventory
            player.Inventory.Add(greaterHealthPotion);
            player.Inventory.Add(lesserHealthPotion);
            player.Inventory.Add(iornChestplate);
            #endregion Populate Player Inventory

            #region Display Generated Values
            #region Show Player Race/Class
            System.Console.WriteLine("{2} is a {0} {1}.", player.Race.ToString(), player.Class.ToString(), player.Name);
            #endregion Show Player Race/Class


            #region Show Player HPs
            System.Console.WriteLine(" {2}'s HP = {0}/{1}.", player.CurrentHealth, player.MaximumHealth, player.Name);
            var potion = (HealthPotionBase)player.Inventory.Find(i => i.Name == "Greater Health Potion");
            potion.Consume(player);
            player.Inventory.Remove(potion);
            System.Console.WriteLine(" {2}'s HP = {0}/{1}.", player.CurrentHealth, player.MaximumHealth, player.Name);
            #endregion Show Player HPs

            #region Show Player Stats
            System.Console.WriteLine("");
            System.Console.WriteLine(" {0}'s Abilities are: ", player.Name);
            foreach (var a in player.Abilities)
            {
                var rule = ruleSet.GetRuleByStatValue(a.Value);
                System.Console.WriteLine("      {0}: {1} which is {2} ({3}).", a.Type.ToString(), a.Value, rule.Name, rule.Modifier);
            }
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine(" {0}'s Skills are: ", player.Name);
            foreach (var s in player.Skills)
            {
                System.Console.WriteLine("      {0}: {1}.", s.Type.ToString(), player.GetSkillScore(s.Type));
            }
            System.Console.WriteLine("");
            #endregion Show Player Stats

            #region Show Player Cash
            System.Console.WriteLine(
                "{4} has {0} plat, {1} gold, {2} silver, {3} copper.",player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper, player.Name
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
                System.Console.WriteLine("Command List:");
                System.Console.WriteLine("HealMe");
                System.Console.WriteLine("GiveMoney");
                System.Console.WriteLine("GiveItem");
                System.Console.WriteLine("Quit");
                string comand = "null";
                {
                    comand = System.Console.ReadLine();

                    #region GiveMoneyCmd
                    if (comand == "GiveMoney")
                    {
                        System.Console.Clear();
                        string amountAdd = "";
                        bool moneyInputed = false;
                        int amountMoneyAddInt;
                        while (moneyInputed == false)
                        {
                            System.Console.WriteLine("You have {0} Plat, {1} Gold, {2} Silver, and {3} Copper.", player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper);
                            System.Console.WriteLine("How Much?");
                            amountAdd = System.Console.ReadLine();
                            bool correctCash = int.TryParse(amountAdd, out amountMoneyAddInt);
                            if (correctCash == true) 
                            {
                                moneyInputed = true;
                            }
                        };
                            int amountAddint = System.Convert.ToInt32(amountAdd);
                            player.Money.AddMoney(copper: amountAddint);
                            System.Console.WriteLine("You have {0} Plat, {1} Gold, {2} Silver, and {3} Copper now!", player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper);
                            System.Console.ReadLine();
                    };
                    #endregion
                    #region HealCmd
                    if (comand == "HealMe")
                    {
                        System.Console.Clear();
                        string amountHeal = "";
                        bool ammountinputed = false;
                        int amountHealInt;
                        while (ammountinputed == false)
                        {
                            System.Console.WriteLine("You have {0}/{1} HP.", player.CurrentHealth, player.MaximumHealth);
                            System.Console.WriteLine("Heal for?");
                            amountHeal = System.Console.ReadLine();
                            bool correctHeal = int.TryParse(amountHeal, out amountHealInt);
                            if (correctHeal == true)
                            {
                                ammountinputed = true;
                            }
                        }
                        amountHealInt = System.Convert.ToInt32(amountHeal);
                        var hackHP = new HealthPotionBase("hackHP", new Money(copper: 0),0 , amountHealInt);
                        var hackPotion = (HealthPotionBase)player.Inventory.Find(i => i.Name == "hackHP");
                        player.Inventory.Add(hackHP);
                        hackHP.Consume(player);
                        player.Inventory.Remove(hackHP);
                        System.Console.WriteLine("You have now {0}/{1} HP.", player.CurrentHealth, player.MaximumHealth);
                        System.Console.ReadLine();
                        System.Console.Clear();
                    };
                    #endregion
                    #region GiveItemCmd
                    if (comand == "GiveItem")
                    {
                        System.Console.WriteLine("Name:");
                        string itemName = System.Console.ReadLine();
                    }
                    #endregion
                    #region QuitCmd
                    if (comand == "Quit")
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Are you sure? y/n");
                        var quitInput = System.Console.ReadLine();
                        if (quitInput == "y")
                        {
                            break;
                        }

                    }; 
                    #endregion
                };
            };
            #endregion Test Console App

        }
    }
}
