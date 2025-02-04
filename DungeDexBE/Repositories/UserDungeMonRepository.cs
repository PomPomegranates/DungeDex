using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;

namespace DungeDexBE.Repositories
{

    public class UserDungeMonRepository : IUserDungeMonRepository
	{
		//private readonly IHttpClientFactory _httpClient;
		private readonly MyDbContext myDbContext;

		public UserDungeMonRepository(IHttpClientFactory httpClient, MyDbContext myDbContext)
		{
			//_httpClient = httpClient;
			this.myDbContext = myDbContext;
		}

		public List<DungeMon>? GetMonsters()
		{
			try
			{

				return myDbContext.MonsterDb.AsNoTracking().Include(m=> m.Spells).ToList();
				

			}
			catch { return null; }
		}

		public (DungeMon?, string) GetSingularMonster(int id)
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


        public (DungeMon, string) PostUserMonster(DungeMon monster)
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
