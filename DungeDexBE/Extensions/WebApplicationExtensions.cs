using DungeDexBE.Models;
using DungeDexBE.Persistence;
using Microsoft.AspNetCore.Identity;

namespace DungeDexBE.Extensions
{
	public static class WebApplicationExtensions
	{
		public static async Task<WebApplication> SeedDatabase(this WebApplication webApplication)
		{
			try
			{
				var scope = webApplication.Services.CreateScope();
				var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
				if (db == null) throw new ApplicationException($"Db could not be resolved during application startup.");
				await db.Database.EnsureDeletedAsync();
				await db.Database.EnsureCreatedAsync();

				var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
				if (userManager == null) throw new ApplicationException($"UserManager could not be resolved during application startup.");
				var user1 = new User { UserName = "Testina", NormalizedUserName = "testina", Email = "testina@test.com", EmailConfirmed = true, NormalizedEmail = "testina@test.com" };
				var user2 = new User { UserName = "Testino", NormalizedUserName = "testino", Email = "testino@test.com", EmailConfirmed = true, NormalizedEmail = "testino@test.com" };
				var result1 = await userManager.CreateAsync(user1, "Password1!");
				var result2 = await userManager.CreateAsync(user2, "Password2!");

				if (!result1.Succeeded || !result2.Succeeded)
				{
					foreach (var error in result1.Errors)
					{
						Console.WriteLine($"ERROR: {error.Description}");
					}
					throw new ApplicationException("Failed to seed users.");
				}
				user1 = await userManager.FindByNameAsync("Testina");
				user2 = await userManager.FindByNameAsync("Testino");
				if (user1 == null || user2 == null) throw new ApplicationException("Unable to seed Db with users.");

				Spell spell1 = new() { Name = "Goodberry", Description = "Up to ten berries appear in your hand and are infused with magic for the duration. A creature can use its action to eat one berry. Eating a berry restores 1 hit point, and the berry provides enough nourishment to sustain a creature for a day." };
				Spell spell2 = new() { Name = "Sunbeam", Description = "A beam of brilliant light flashes out fro m your hand in a 5-foot-wide, 60-foot-long line. Each creature in the line must make a constitution saving throw. On a failed save, a creature takes 6d8 radiant damage and is blinded until your next turn. On a successful save, it takes half as much damage and isn't blinded by this spell. Undead and oozes have disadvantage on this saving throw." };
				Spell spell3 = new() { Name = "Acid Splash", Description = "You hurl a bubble of acid. Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a dexterity saving throw or take 1d6 acid damage." };

				Spell spell4 = new()
				{
					Name = "Sunburst",
					Description = "Brilliant sunlight flashes in a 60-foot radius centered on a point you choose within range. Each creature in that light must make a constitution saving throw. On a failed save, a creature takes 12d6 radiant damage and is blinded for 1 minute. On a successful save, it takes half as much damage and isn't blinded by this spell. Undead and oozes have disadvantage on this saving throw."
				};
				MonsterAction LilligantAction = new MonsterAction()
				{
					Name = "Tackle",
					Description = "Melee: +5 to hit, reach 5 ft. Hit: 4d6 + 0 Bludgeoning damage."
				};
				MonsterAction VenusaurAction = new MonsterAction()

				{
					Name = "Tackle",
					Description = "Melee: +6 to hit, reach 5 ft. Hit: 3d8 + 1 Bludgeoning damage."


				};
				MonsterAction BayleefAction = new MonsterAction()
				{
					Name = "Tackle",
					Description = "Melee: +4 to hit, reach 5 ft. Hit: 3d6 + 0 Bludgeoning damage."
				};

				var monster1 = new Dungemon
				{
					BasePokemon = "Lilligant",
					NickName = "Lilly",
					UserId = user1.Id,
					Spells = [spell4],
					ChallengeRating = 12,
					ArmorClass = 12,
					HitPoints = 100,
					Strength = 14,
					Constitution = 13,
					Wisdom = 14,
					Intelligence = 12,
					Dexterity = 18,
					Charisma = 9,

					Cry = "https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/549.ogg",
					ImageLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/549.png",
					SpriteLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/549.png",
					Actions = [LilligantAction],
					Description = "Even veteran Trainers face a challenge in getting its beautiful flower to bloom. This Pokémon is popular with celebrities.",
					Proficiencies = "Nature +8",
				};

				var monster2 = new Dungemon
				{

					BasePokemon = "Venusaur",
					NickName = "Venusaur",
					UserId = user2.Id,
					ChallengeRating = 16,
					ProficiencyBonus = 5,
					ArmorClass = 19,
					Strength = 13,
					Dexterity = 13,
					Constitution = 10,
					Intelligence = 16,
					Wisdom = 12,
					Charisma = 12,
					HitPoints = 306,
					ImageLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/3.png",
					SpriteLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/3.png",
					Actions = [VenusaurAction],
					Spells = [spell1, spell2],
					Cry = "https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/3.ogg",
					Proficiencies = "Medicine +6",
					Description = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight."

				};

				var monster3 = new Dungemon
				{

					BasePokemon = "Bayleef",
					NickName = "Baybeee",
					UserId = user2.Id,
					User = user2,
					ChallengeRating = 12,
					ArmorClass = 12,
					HitPoints = 100,
					Strength = 14,
					Constitution = 13,
					Wisdom = 14,
					Intelligence = 12,
					Dexterity = 18,
					Charisma = 9,
					Spells = [spell3],
					Actions = [BayleefAction],
					Proficiencies = "Nature +3",
					Cry = "https://raw.githubusercontent.com/PokeAPI/cries/main/cries/pokemon/latest/153.ogg",
					Description = "BAYLEEF’s neck is ringed by curled-up leaves. Inside each tubular leaf is a small shoot of a tree. The fragrance of this shoot makes people peppy.",
					ImageLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/153.png",
					SpriteLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/153.png",

				};
				await db.Dungemon.AddRangeAsync(monster1, monster2, monster3);
				await db.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
			return webApplication;
		}
	}
}
