using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Repositories
{

    public class UserDungeMonRepository : IUserDungeMonRepository
	{
		private readonly MyDbContext myDbContext;

		public UserDungeMonRepository(MyDbContext myDbContext)
		{
			this.myDbContext = myDbContext;
		}

		public List<DungeMon>? GetMonsters()
		{
			try
			{
				return myDbContext.MonsterDb.AsNoTracking().Include(m=> m.Spells).ToList();
			}
			catch 
			{
				return null; 
			}
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

		public (DungeMon, string) PatchUserMonster(DungeMon monster)
		{
            try
            {
				var monsterToChange = myDbContext.MonsterDb.Single(x => x.Id == monster.Id);
				myDbContext.Entry(monsterToChange).CurrentValues.SetValues(monster);
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
