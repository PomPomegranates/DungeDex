using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {

        public List<User>? GetUsers();

        public User? GetUserByName(string name);
        public (User, string) PostUser(User newUser);
    }
}
