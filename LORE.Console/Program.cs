using LORE.Entities.Characters;
using LORE.Entities.Items.Potions;
using LORE.Entities.Mechanics.Rules;
using LORE.Entities.Misc;
using LORE.MiddeTier.Rules;
using LORE.Entities.Mechanics.Start;
using LORE.Entities.Mechanics;
using System;


namespace LORE.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new PlayerBase(null)
            {
                CurrentHealth = 10,
                MaximumHealth = 40,
                Money = new Money(),
                Level = 1,
                CurrentXp = 0,
                XpNeeded = 100

            };
            Start.CreatePlayer(player);
            #region Test Console App
            var ruleSet = new AbilityScoreRules();

            #region Item Creation
            var greaterHealthPotion = new HealthPotionBase("Greater Health Potion", new Money(silver: 20), 0.5, 20);
            var lesserHealthPotion = new HealthPotionBase("Lesser Health Potion", new Money(copper: 20), 0.5, 10);
            //var iornChestplate = new ArmorBase("Iorn Chestplate", new Money(platinum: 1, gold: 1, silver: 50), EquipmentType.Chest, 10, 5, 1, 8, 0, 0, 0, 0);
            #endregion Item Creation
            #region Player Creation


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
                System.Console.WriteLine("A: Dwarf");
                System.Console.WriteLine("");
                System.Console.WriteLine("B: Elf");
                System.Console.WriteLine("");
                System.Console.WriteLine("C: Halfling");
                System.Console.WriteLine("");
                System.Console.WriteLine("D: Human");
                System.Console.WriteLine("");
                System.Console.WriteLine("E: Orc");
                System.Console.WriteLine("");
                ConsoleKeyInfo info = System.Console.ReadKey();
                if (info.Key == ConsoleKey.A)
                {
                    player.AssignRace(RaceType.Dwarf);
                    raceSelected = true;
                    break;
                }
                if (info.Key == ConsoleKey.B)
                {
                    player.AssignRace(RaceType.Elf);
                    raceSelected = true;
                    break;
                }
                if (info.Key == ConsoleKey.C)
                {
                    player.AssignRace(RaceType.Halfling);
                    raceSelected = true;
                    break;
                }
                if (info.Key == ConsoleKey.D)
                {
                    player.AssignRace(RaceType.Human);
                    raceSelected = true;
                    break;
                }
                if (info.Key == ConsoleKey.E)
                {
                    player.AssignRace(RaceType.Orc);
                    raceSelected = true;
                    break;
                }

                System.Console.Clear();
            };
            System.Console.Clear();

            bool classChoosen = false;
            while (classChoosen == false)
            {
                System.Console.WriteLine("Choose a Class");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("A: Bard");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("B: Berserker");
                System.Console.WriteLine("");
                System.Console.WriteLine("C: Crusader");
                System.Console.WriteLine("");
                System.Console.WriteLine("D: Elementalist");
                System.Console.WriteLine("");
                System.Console.WriteLine("E: Monk");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("F: Priest");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("G: Ranger");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("H: Rogue");
                System.Console.WriteLine("");
                ConsoleKeyInfo info = System.Console.ReadKey();
                if (info.Key == ConsoleKey.A)
                {
                    player.AssignClass(ClassType.Bard);
                    classChoosen = true;
                    break;
                }
                if (info.Key == ConsoleKey.B)
                {
                    player.AssignClass(ClassType.Berserker);
                    classChoosen = true;
                    break;
                }
                if (info.Key == ConsoleKey.C)
                {
                    player.AssignClass(ClassType.Crusader);
                    classChoosen = true;
                    break;
                }
                 if (info.Key == ConsoleKey.D)
                {
                    player.AssignClass(ClassType.Elementalist);
                    classChoosen = true;
                    break;
                }
                if (info.Key == ConsoleKey.E)
                {
                    player.AssignClass(ClassType.Monk);
                    classChoosen = true;
                    break;
                }
                if (info.Key == ConsoleKey.F)
                {
                    player.AssignClass(ClassType.Priest);
                    classChoosen = true;
                    break;
                }
                if (info.Key == ConsoleKey.G)
                {
                    player.AssignClass(ClassType.Ranger);
                    classChoosen = true;
                    break;
                }
                if (info.Key == ConsoleKey.H)
                {
                    player.AssignClass(ClassType.Rogue);
                    classChoosen = true;
                    break;
                }
               
                 System.Console.Clear();
            };
            System.Console.Clear();
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
                System.Console.WriteLine("Character: {0}", player.Name);
                System.Console.WriteLine("");
                System.Console.WriteLine("-------------Command List--------------");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("(H)eal Me");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("(G)ive Money");
                System.Console.WriteLine(" ");
                System.Console.WriteLine("(Q)uit");
                System.Console.WriteLine(" ");

                ConsoleKeyInfo info = System.Console.ReadKey();
                if (info.Key == ConsoleKey.G)
                {
                    Comands.GiveMoney(player);
                }
                if (info.Key == ConsoleKey.H)
                {
                    Comands.HealMe(player);
                }
                if (info.Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
            };
            #endregion
            #endregion

        }
    }
}


/* have dad explain polymorphism and inheritace to me **/
/* 

if (info.Key == ConsoleKey.)
{

}

**/