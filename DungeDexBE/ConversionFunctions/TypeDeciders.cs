using DungeDexBE.Models;

namespace DungeDexBE.ConversionFunctions
{
	public static class TypeDeciders
	{
		public static void AssignDungemonType(this Dungemon dungemon, Pokemon pokemon)
		{
			Random random = new Random();
			List<string> possibleTypes = new List<string>();

			AbberationCheck(possibleTypes, pokemon);
			BeastCheck(possibleTypes, pokemon);
			CelestialCheck(possibleTypes, pokemon);
			ConstructCheck(possibleTypes, pokemon);
			DragonCheck(possibleTypes, pokemon);
			ElementalCheck(possibleTypes, pokemon);
			FeyCheck(possibleTypes, pokemon);
			FiendCheck(possibleTypes, pokemon);
			GiantCheck(possibleTypes, pokemon);
			HumanoidCheck(possibleTypes, pokemon);
			MonstrosityCheck(possibleTypes, pokemon);
			OozeCheck(possibleTypes, pokemon);
			PlantCheck(possibleTypes, pokemon);
			UndeadCheck(possibleTypes, pokemon);

			if (possibleTypes.Count > 0)
			{
				dungemon.Type = possibleTypes[random.Next(possibleTypes.Count)];
			}
			else
			{
				dungemon.Type = possibleTypes[random.Next(PossibleNonSpecificTypes.Count)];
			}
		}

		private static List<string> PossibleNonSpecificTypes = new List<string>
		{
			"Celestial",
			"Fiend",
			"Monstrosity"
		};

		private static void AbberationCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.pokemonId <= 789 && pokemon.pokemonId >= 800) possibleTypes.Add("Abberation");
		}

		private static void BeastCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "normal" || pokemon.Type2 == "normal") possibleTypes.Add("Beast");
		}

		private static void CelestialCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "fairy" || pokemon.Type2 == "fairy") possibleTypes.Add("Celestial");
		}

		private static void ConstructCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "steel" || pokemon.Type2 == "steel") possibleTypes.Add("Construct");
		}

		private static void DragonCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "dragon" || pokemon.Type2 == "dragon") possibleTypes.Add("Dragon");
		}

		private static void ElementalCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "fire" || pokemon.Type2 == "fire"
				|| pokemon.Type1 == "rock" || pokemon.Type2 == "rock"
				|| pokemon.Type1 == "ground" || pokemon.Type2 == "ground"
				|| pokemon.Type1 == "water" || pokemon.Type2 == "water"
				|| pokemon.Type1 == "flying" || pokemon.Type2 == "flying")
				possibleTypes.Add("Elemental");
		}

		private static void FeyCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "fairy" || pokemon.Type2 == "fairy") possibleTypes.Add("Fey");
		}

		private static void FiendCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "dark" || pokemon.Type2 == "dark") possibleTypes.Add("Fiend");
		}

		private static void GiantCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			// Don't currently think any Pokemon should fall into this category.
		}

		private static void HumanoidCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Shape == "upright" || pokemon.Shape == "humanoid") possibleTypes.Add("Humanoid");
		}

		private static void MonstrosityCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			// Can't currently think of a way to single out pokemon for this category
		}

		private static void OozeCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "poison" || pokemon.Type2 == "poison") possibleTypes.Add("Ooze");
		}

		private static void PlantCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "grass" || pokemon.Type2 == "grass") possibleTypes.Add("Plant");
		}

		private static void UndeadCheck(List<string> possibleTypes, Pokemon pokemon)
		{
			if (pokemon.Type1 == "ghost" || pokemon.Type2 == "ghost") possibleTypes.Add("Undead");
		}
	}
}
