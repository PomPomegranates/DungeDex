using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Repositories
{
	public class UserDungeMonRepository : IUserDungeMonRepository
	{
		private readonly MyDbContext myDbContext;

		public UserDungeMonRepository(MyDbContext myDbContext)
		{
			this.myDbContext = myDbContext;
		}

		public List<Dungemon>? GetMonsters(DungemonFilterDto filterDto)
		{
			try
			{
				var dungemon = myDbContext.MonsterDb.AsQueryable<Dungemon>();

				if (!string.IsNullOrEmpty(filterDto.BasePokemon))
					dungemon = dungemon.Where(d => d.BasePokemon == filterDto.BasePokemon);

				dungemon = dungemon.Skip(filterDto.Offset).Take(filterDto.Number);

				return dungemon.ToList();
			}
			catch
			{
				return null;
			}
		}

		public (Dungemon?, string) GetSingularMonster(int id)
		{
			var value = myDbContext.MonsterDb.Where(x => (x.Id == id)).FirstOrDefault();

			try
			{
				if (value != null)
				{
					return (value, "Success");
				}
				else
				{
					return (null, $"No Userdata for Pokemon Number {id}");
				}
			}
			catch (Exception e)
			{
				return (null, e.Message);
			}
		}


		public (Dungemon, string) PostUserMonster(Dungemon monster)
		{
			try
			{
				myDbContext.MonsterDb.Add(monster);
				myDbContext.SaveChanges();
				return (monster, "Success");

			}
			catch (Exception e)
			{
				return (monster, e.Message);
			}


		}

		public (Dungemon, string) PatchUserMonster(Dungemon monster)
		{
			try
			{
				var monsterToChange = myDbContext.MonsterDb.Single(x => x.Id == monster.Id);
				myDbContext.MonsterDb.Entry(monsterToChange).CurrentValues.SetValues(monster);
				myDbContext.SaveChanges();
				return (monster, "Success");
			}
			catch (Exception e)
			{
				return (monster, e.Message);
			}
		}

		public string DeleteUserMonster(int monsterId)
		{
			try
			{
				var existingMonster = myDbContext.MonsterDb.Single(m => m.Id == monsterId);
				myDbContext.MonsterDb.Remove(existingMonster);
				myDbContext.SaveChanges();
				return "Success";
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}
	}
}
