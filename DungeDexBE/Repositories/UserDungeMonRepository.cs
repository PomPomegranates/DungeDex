using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;
using DungeDexBE.Persistence;

namespace DungeDexBE.Repositories
{
	public class UserDungeMonRepository : IUserDungeMonRepository
	{
		private readonly ApplicationDbContext _db;

		public UserDungeMonRepository(ApplicationDbContext dbContext)
		{
			_db = dbContext;
		}

		public List<Dungemon>? GetDungemon(DungemonFilterDto filterDto)
		{
			try
			{
				var dungemon = _db.Dungemon.AsQueryable<Dungemon>();

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

		public (Dungemon?, string) GetDungemonById(int id)
		{
			var value = _db.Dungemon.Where(x => (x.Id == id)).FirstOrDefault();

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


		public (Dungemon, string) AddDungemon(Dungemon monster)
		{
			try
			{
				_db.Dungemon.Add(monster);
				_db.SaveChanges();
				return (monster, "Success");
			}
			catch (Exception e)
			{
				return (monster, e.Message);
			}
		}

		public (Dungemon, string) UpdateDungemon(Dungemon monster)
		{
			try
			{
				var monsterToChange = _db.Dungemon.Single(x => x.Id == monster.Id);
				_db.Dungemon.Entry(monsterToChange).CurrentValues.SetValues(monster);
				_db.SaveChanges();
				return (monster, "Success");
			}
			catch (Exception e)
			{
				return (monster, e.Message);
			}
		}

		public string DeleteDungemonById(int monsterId)
		{
			try
			{
				var existingMonster = _db.Dungemon.Single(m => m.Id == monsterId);
				_db.Dungemon.Remove(existingMonster);
				_db.SaveChanges();
				return "Success";
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}
	}
}
