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

		public (Monster?, string) GetSingularMonster(int id)
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
            } catch (Exception e)
			{
				return (null, e.Message);
			}



        }

        public (Monster, string) PostUserMonster(Monster monster)
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

    }
}
