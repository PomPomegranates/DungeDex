using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
	public interface IUserRepository
	{
		public List<User>? GetUsers();


		public User? GetUserByName(string name);
		public (User, string) PostUser(User newUser);


	}
}
