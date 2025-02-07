using DungeDexBE.Models;

namespace DungeDexBE.ConversionFunctions
{
	public static class ProficiencyDeciders
	{
		public static void UpdateDungemon(Dungemon dungemon, Pokemon pokemon)
		{
			var possibleProficiencies = DetermineAllProficienciesByChance(dungemon, pokemon);
			string proficiencies = FlattenProficienciesIntoString(possibleProficiencies, dungemon);
			dungemon.Proficiencies = proficiencies;
		}
		public static string FlattenProficienciesIntoString(List<string> proficiencies, Dungemon dungemon)
		{
			string result = string.Empty;

			if (proficiencies.Contains("Athletics"))
			{
				result += $"Athletics +{Convert.GetModifier(dungemon.Strength) + dungemon.ProficiencyBonus},";
			}

			if (proficiencies.Contains("Acrobatics"))
			{
				result += $"Acrobatics +{Convert.GetModifier(dungemon.Dexterity) + dungemon.ProficiencyBonus},";
			}

			if (proficiencies.Contains("Arcana"))
			{
				result += $"Arcana +{Convert.GetModifier(dungemon.Intelligence) + dungemon.ProficiencyBonus},";
			}

			if (proficiencies.Contains("Deception"))
			{
				result += $"Deception +{Convert.GetModifier(dungemon.Charisma) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("History"))
			{
				result += $"History +{Convert.GetModifier(dungemon.Intelligence) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Intimidation"))
			{
				result += $"Intimidation +{Convert.GetModifier(dungemon.Charisma) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Investigation"))
			{
				result += $"Investigation +{Convert.GetModifier(dungemon.Charisma) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Medicine"))
			{
				result += $"Medicine +{Convert.GetModifier(dungemon.Wisdom) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Nature"))
			{
				result += $"Nature +{Convert.GetModifier(dungemon.Intelligence) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Perception"))
			{
				result += $"Perception +{Convert.GetModifier(dungemon.Wisdom) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Performance"))
			{
				result += $"Performance +{Convert.GetModifier(dungemon.Charisma) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Persuasion"))
			{
				result += $"Persuasion +{Convert.GetModifier(dungemon.Charisma) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Sleight Of Hand"))
			{
				result += $"Sleight Of Hand +{Convert.GetModifier(dungemon.Charisma) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Stealth"))
			{
				result += $"Stealth +{Convert.GetModifier(dungemon.Dexterity) + dungemon.ProficiencyBonus}, ";
			}

			if (proficiencies.Contains("Survival"))
			{
				result += $"Survival +{Convert.GetModifier(dungemon.Wisdom) + dungemon.ProficiencyBonus}, ";
			}

			result = result.Trim([',', ' ']);
			return result;
		}
		public static List<string> DetermineAllProficienciesByChance(Dungemon dungemon, Pokemon pokemon)
		{
			var result = new List<string>();

			AssignAthleticsbyChance(result, dungemon, pokemon);
			AssignAcrobaticsbyChance(result, dungemon, pokemon);
			AssignArcanabyChance(result, dungemon, pokemon);
			AssignDeceptionbyChance(result, dungemon, pokemon);
			AssignHistorybyChance(result, dungemon, pokemon);
			AssignIntimidationbyChance(result, dungemon, pokemon);
			AssignInvestigationbyChance(result, dungemon, pokemon);
			AssignMedicinebyChance(result, dungemon, pokemon);
			AssignNaturebyChance(result, dungemon, pokemon);
			AssignPerceptionbyChance(result, dungemon, pokemon);
			AssignPerformancebyChance(result, dungemon, pokemon);
			AssignPersuasionbyChance(result, dungemon, pokemon);
			AssignSleightOfHandbyChance(result, dungemon, pokemon);
			AssignStealthbyChance(result, dungemon, pokemon);
			AssignSurvivalbyChance(result, dungemon, pokemon);

			return result;

		}
		
		private static Random random = new Random();

		public static void AssignAthleticsbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.Type1 == "fighting" || pokemon.Type2 == "fighting")
			{
				if (random.Next(2) == 1) possibleList.Add("Athletics");
			}
		}
		public static void AssignAcrobaticsbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			// What could decide this?
		}
		public static void AssignArcanabyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.Type1 == "psychic"
				|| pokemon.Type2 == "psychic"
				|| pokemon.Type1 == "fairy"
				|| pokemon.Type2 == "fairy")
			{
				if (random.Next(2) == 1) possibleList.Add("Arcana");
			}
		}
		public static void AssignDeceptionbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.Type1 == "dark" || pokemon.Type2 == "dark")
			{
				if (random.Next(2) == 1) possibleList.Add("Deception");
			}
		}
		public static void AssignHistorybyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.IsLegendaryOrMythical) 
			{ 
				if (random.Next(2) == 1) possibleList.Add("History"); 
			}
		}
		public static void AssignIntimidationbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			// Could implement getting Pokemon Ability, and if one of them is Intimidate, could give it this
			if (pokemon.Type1 == "dragon" || pokemon.Type2 == "dragon")
			{
				if (random.Next(2) == 1) possibleList.Add("Intimidation");
			}
		}
		public static void AssignInvestigationbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			// What could decide this?
		}
		public static void AssignMedicinebyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.Type1 == "grass"
			|| pokemon.Type2 == "grass"
			|| pokemon.Type1 == "fairy"
			|| pokemon.Type2 == "fairy")
			{
				if (random.Next(2) == 1) possibleList.Add("Medicine");
			}
		}
		public static void AssignNaturebyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.Type1 == "normal"
			|| pokemon.Type2 == "normal"
			|| pokemon.Type1 == "grass"
			|| pokemon.Type2 == "grass")
			{
				if (random.Next(2) == 1) possibleList.Add("Nature");
			}
		}
		public static void AssignPerceptionbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.Type1 == "psychic"
			|| pokemon.Type2 == "psychic")
			{
				if (random.Next(2) == 1) possibleList.Add("Perception");
			}
		}
		public static void AssignPerformancebyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			// What could decide this?
		}
		public static void AssignPersuasionbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.Shape == "upright")
			{
				if (random.Next(2) == 1) possibleList.Add("Persuasion");
			}
		}
		public static void AssignSleightOfHandbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			if (pokemon.Type1 == "dark" || pokemon.Type2 == "dark")
			{
				if (random.Next(2) == 1) possibleList.Add("Sleight Of Hand");
			}
		}
		public static void AssignStealthbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			// What could decide this? Dungemon size?
		}
		public static void AssignSurvivalbyChance(List<string> possibleList, Dungemon dungemon, Pokemon pokemon)
		{
			// What could decide this?
		}

	}
}
