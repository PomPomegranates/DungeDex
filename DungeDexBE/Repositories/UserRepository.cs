using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _db;

		public UserRepository(ApplicationDbContext dbContext)
		{
			_db = dbContext;
		}

		public List<User>? GetUsers()
		{
			try
			{
				return _db.Users.AsNoTracking().Include(m => m.Dungemon).ToList();
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
				_db.Users.Add(newUser);
				_db.SaveChanges();
				return (newUser, "Success");
			}
			catch (Exception e)
			{
				return (newUser, e.Message);
			}
		}
	}
}
