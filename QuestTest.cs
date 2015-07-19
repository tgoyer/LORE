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
    	Console.WriteLine ("You see a strange man sitting in the forest. What should you do?");
    	
    	Console.WriteLine("1) Yell at him.")
		
		Console.WriteLine("2) Try to sneak up on him (rouge class)")

		Console.WriteLine("3) Walk away.")

		var response = Console.ReadLine();

		if (response == "1" || response == "2" || response == "3") {

		} else{

		};
		
    }
}
