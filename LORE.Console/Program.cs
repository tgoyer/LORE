using System.Globalization;
using LORE.Entities.Characters;
using LORE.Entities.Items;
using LORE.Entities.Items.Potions;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;
using LORE.MiddeTier.Rules;
using LORE.Entities.Mechanics;
using LORE.Entities.Mechanics.Start;
using LORE.Console;



namespace LORE.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            #region Test Console App
            var ruleSet = new AbilityScoreRules();

            #region Item Creation
            var greaterHealthPotion = new HealthPotionBase("Greater Health Potion", new Money(silver: 20), 0.5, 20);
            var lesserHealthPotion = new HealthPotionBase("Lesser Health Potion", new Money(copper: 20), 0.5, 10);
            //var iornChestplate = new ArmorBase("Iorn Chestplate", new Money(platinum: 1, gold: 1, silver: 50), EquipmentType.Chest, 10, 5, 1, 8, 0, 0, 0, 0);
            #endregion Item Creation
            #region Player Creation
            var player = new PlayerBase(null)
            {
                CurrentHealth = 10,
                MaximumHealth = 40,
                Money = new Money(),
                Level = 1,
                CurrentXp = 0,
                XpNeeded = 100

            };
            Start.AskName(player);
            System.Console.Clear();

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
                System.Console.WriteLine("");
                System.Console.WriteLine("Dwarf");
                System.Console.WriteLine("");
                System.Console.WriteLine("Elf");
                System.Console.WriteLine("");
                System.Console.WriteLine("Halfling");
                System.Console.WriteLine("");
                System.Console.WriteLine("Human");
                System.Console.WriteLine("");
                var selectedRace = System.Console.ReadLine();
                selectedRace = myTI.ToTitleCase(selectedRace);
                {
                    switch (selectedRace)
                    {
                        case "Elf":
                            player.AssignRace(RaceType.Elf);
                            raceSelected = true;
                            break;
                        case "Dwarf":
                            player.AssignRace(RaceType.Dwarf);
                            raceSelected = true;
                            break;
                        case "Halfling":
                            player.AssignRace(RaceType.Halfling);
                            raceSelected = true;
                            break;
                        case "Human":
                            player.AssignRace(RaceType.Human);
                            raceSelected = true;
                            break;
                        case "Orc":
                            player.AssignRace(RaceType.Orc);
                            raceSelected = true;
                            break;
                        default:
                            break;
                    }
                };
                System.Console.Clear();
            };
            System.Console.Clear();

            bool classChoosen = false;
            while (classChoosen == false)
            {
                System.Console.WriteLine("Choose a Class");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Bard");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Berserker");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Crusader");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Elementalist");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Monk");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Priest");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Ranger");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Rogue");
                System.Console.WriteLine("");

                var chosenClass = System.Console.ReadLine();
                chosenClass = myTI.ToTitleCase(chosenClass);
                switch (chosenClass)
                {
                    case "Bard":
                        player.AssignClass(ClassType.Bard);
                        classChoosen = true;
                        break;
                    case "Berserker":
                        player.AssignClass(ClassType.Berserker);
                        classChoosen = true;
                        break;
                    case "Crusader":
                        player.AssignClass(ClassType.Crusader);
                        classChoosen = true;
                        break;
                    case "Elementalist":
                        player.AssignClass(ClassType.Elementalist);
                        classChoosen = true;
                        break;
                    case "Monk":
                        player.AssignClass(ClassType.Monk);
                        classChoosen = true;
                        break;
                    case "Priest":
                        player.AssignClass(ClassType.Priest);
                        classChoosen = true;
                        break;
                    case "Ranger":
                        player.AssignClass(ClassType.Ranger);
                        classChoosen = true;
                        break;
                    case "Rogue":
                        player.AssignClass(ClassType.Rogue);
                        classChoosen = true;
                        break;
                    default:
                        break;
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
            // player.Inventory.Add(iornChestplate);
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
                "{4} has {0} plat, {1} gold, {2} silver, {3} copper.", player.Money.Platinum, player.Money.Gold, player.Money.Silver, player.Money.Copper, player.Name
            );
            System.Console.WriteLine("Inventory:");
            #endregion Show Player Cash

            #region Show Player Inventory
            Entities.Mechanics.Comands.ShowInventory(player);
            #endregion Show Player Inventory
            #endregion Display Generated Values

            System.Console.WriteLine("Press Enter");
            System.Console.ReadLine();

            #region commands
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("-------------Command List--------------");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Heal Me -- WIP");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Give Money");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("Quit");
                System.Console.WriteLine(" ");

                var response = myTI.ToTitleCase(System.Console.ReadLine());
                switch (response)
                {
                    case "Give Money":
                        Comands.GiveMoney(player);
                        break;
                    case "Quit":
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            };
            #endregion
            #endregion

        }
    }
}


/* have dad explain polymorphism and inheritace to me **/