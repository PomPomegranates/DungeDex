using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Repositories
{
    public class UserPokemonsterRepository : IUserPokemonsterRepository
	{
		//private readonly IHttpClientFactory _httpClient;
		private readonly MyDbContext myDbContext;

		public UserPokemonsterRepository(IHttpClientFactory httpClient, MyDbContext myDbContext)
		{
			//_httpClient = httpClient;
			this.myDbContext = myDbContext;
		}

		public List<Monster>? GetMonsters()
		{
			try
			{
				return myDbContext.MonsterDb.ToList();
				
			}
			catch { return null; }
		}
	}
}
