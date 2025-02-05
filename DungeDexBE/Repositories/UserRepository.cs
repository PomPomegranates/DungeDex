using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly MyDbContext myDbContext;

		public UserRepository(MyDbContext db)
		{
			myDbContext = db;
		}

		public List<User>? GetUsers()
		{
			//get all users
			try
			{
				return myDbContext.Users.AsNoTracking().Include(m => m.DungeMons).ToList();
			}
			catch
			{
				return null;
			}
		}

		public User? GetUserByName(string name)
		{

			try
			{
				return GetUsers().Where(U => U.UserName == name).FirstOrDefault();

			}
			catch
			{
				return null;
			}
		}

		public (User, string) PostUser(User newUser)
		{
			try
			{
				myDbContext.Users.Add(newUser);
				myDbContext.SaveChanges();
				return (newUser, "Success");

			}
			catch (Exception e)
			{
				return (newUser, e.Message);
			}


		}


	}
}
