using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;
using DungeDexBE.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Repositories
{
	public class UserDungemonRepository : IUserDungemonRepository
	{
		private readonly ApplicationDbContext _db;

		public UserDungemonRepository(ApplicationDbContext dbContext)
		{
			_db = dbContext;
		}

		public async Task<List<Dungemon>?> GetDungemon(DungemonFilterDto filterDto)
		{
			try
			{
				var dungemon = _db.Dungemon.AsQueryable<Dungemon>();

				if (!string.IsNullOrEmpty(filterDto.BasePokemon))
					dungemon = dungemon.Where(d => d.BasePokemon == filterDto.BasePokemon);

				dungemon = dungemon.Skip(filterDto.Offset).Take(filterDto.Number);


				return await dungemon.Include(d => d.Spells).Include(d => d.Actions).ToListAsync();
			}
			catch
			{
				return null;
			}
		}

		public async Task<(Dungemon?, string)> GetDungemonById(int id)
		{
			var value = await _db.Dungemon.Where(x => (x.Id == id)).Include(d => d.Spells).Include(d => d.Actions).FirstOrDefaultAsync();

			var result = value == null
				? $"No Dungémon with Id '{id}' exists"
				: "Success";

			return (value, result);
		}


		public async Task<(Dungemon, string)> AddDungemon(Dungemon monster)
		{
			try
			{
				await _db.Dungemon.AddAsync(monster);
				await _db.SaveChangesAsync();
				return (monster, "Success");
			}
			catch (Exception e)
			{
				return (monster, e.Message);
			}
		}

		public async Task<(Dungemon, string)> UpdateDungemon(Dungemon monster)
		{
			try
			{
				var monsterToChange = await _db.Dungemon.SingleAsync(x => x.Id == monster.Id);
				_db.Dungemon.Entry(monsterToChange).CurrentValues.SetValues(monster);
				await _db.SaveChangesAsync();
				return (monster, "Success");
			}
			catch (Exception e)
			{
				return (monster, e.Message);
			}
		}

		public async Task<string> DeleteDungemonById(int monsterId, string jwtUserId)
		{
			try
			{
				var existingMonster = await _db.Dungemon.SingleOrDefaultAsync(m => m.Id == monsterId);

				if (existingMonster == null) return $"No Dungémon with Id '{monsterId}' could be found.";

				if (existingMonster.UserId != jwtUserId) return "User Id and Dungémon User Id do not match.";

				_db.Dungemon.Remove(existingMonster);
				await _db.SaveChangesAsync();
				return "Success";
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}
	}
}
