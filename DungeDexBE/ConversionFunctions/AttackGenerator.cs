using DungeDexBE.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using DungeDexBE.Models.Dtos;
using DungeDexBE.Enums;

namespace DungeDexBE.ConversionFunctions
{
	public static class AttackGenerator
	{
		public static void GiveMeleeAttack(this Dungemon Dungemon, Pokemon pokemon)
		{
			// Check what moves the pokemon can learn and determine if there is an appropriate one, otherwise:

			// Determine a random one:
			Random rand = new Random();
			int randomIndex = rand.Next(MeleeAttackBases.Count);
			ActionDTO meleeAttack = MeleeAttackBases[randomIndex];

			//Edit base attack with Dungemon data:
			meleeAttack.DamageDice = $"{GetDamageDiceBase(Dungemon.ChallengeRating)} + {Convert.GetModifier(Dungemon.Strength)}";
			meleeAttack.AttackBonus = Convert.GetModifier(Dungemon.Strength) + Dungemon.ProficiencyBonus;

			//Make Action:
			Models.Action finalAction = new Models.Action
			{
				Name = meleeAttack.Name,
				Description = meleeAttack.ToString()
			};

			//Make edits to action based on CR and type (e.g. if Pokemon is Poison type, save or take Poison damage):

			//Give to Dungemon:
			Dungemon.Actions.Add(finalAction);
			
	}

		public static List<ActionDTO> MeleeAttackBases = new List<ActionDTO>
		{
			new ActionDTO
			{
				Name = "Tackle",
				Range = 5,
				ActionType = ActionType.Melee,
				DamageType = Damage.Bludgeoning
			}
		};


		public static string GetDamageDiceBase(float CR)
		{
			Random random = new Random();
			switch (CR)
			{
				case 0f:
					List<string> cr0Damages = new List<string>
					{
						 "1d4"
					};
					return cr0Damages[random.Next(cr0Damages.Count)];
				case 0.125f:
					List<string> crEigthDamages = new List<string>
					{
						"2d4", "1d4"
					};
					return crEigthDamages[random.Next(crEigthDamages.Count)];
				case 0.25f:
					List<string> crQuarterDamages = new List<string>
					{
						"1d6", "1d4", "1d8"
					};
					return crQuarterDamages[random.Next(crQuarterDamages.Count)];
				case 0.5f:
					List<string> crHalfDamages = new List<string>
					{
						"1d8", "1d6", "1d10"
					};
					return crHalfDamages[random.Next(crHalfDamages.Count)];
				case 1f:
					List<string> cr1Damages = new List<string>
					{
						"1d6", "2d6"
					};
					return cr1Damages[random.Next(cr1Damages.Count)];
				case 2f:
					List<string> cr2Damages = new List<string>
					{
						"2d6", "ld8"
					};
					return cr2Damages[random.Next(cr2Damages.Count)];
				case 3f:
					List<string> cr3Damages = new List<string>
					{
						"2d6"
					};
					return cr3Damages[random.Next(cr3Damages.Count)];
				case 4f:
				case 12f:
					List<string> cr4Damages = new List<string>
					{
						"2d6", "2d8"
					};
					return cr4Damages[random.Next(cr4Damages.Count)];
				case 5f:
					List<string> cr5Damages = new List<string>
					{
						"2d6", "2d8", "2d12"
					};
					return cr5Damages[random.Next(cr5Damages.Count)];
				case 8f:
				case 6f:
				case 14f:
					List<string> cr6Damages = new List<string>
					{
						"2d8", "2d12"
					};
					return cr6Damages[random.Next(cr6Damages.Count)];
				case 9f:
				case 7f:
				case 10f:
				case 15f:
				case 16f:
				case 24f:
				
					List<string> cr7Damages = new List<string>
					{
						"3d6", "3d8", "2d10"
					};
					return cr7Damages[random.Next(cr7Damages.Count)];
				case 11f:
				case 17f:
				case 19f:
				case 21f:
				case 22f:
				case 25f:
				case 28f:
					List<string> cr11Damages = new List<string>
					{
						"3d6", "3d8", "2d10"
					};
					return cr11Damages[random.Next(cr11Damages.Count)];
				case 13f:
				case 18f:
				case 26f:
				case 29f:
					List<string> cr13Damages = new List<string>
					{
						"4d6", "4d8", "3d10"
					};
					return cr13Damages[random.Next(cr13Damages.Count)];
				case 20f:
				case 23f:
				case 27f:
				case 30f:
				default:
					List<string> cr20Damages = new List<string>
					{
						"3d6", "3d8", "2d10"
					};
					return cr20Damages[random.Next(cr20Damages.Count)];



			}
		}
	}

	
}
