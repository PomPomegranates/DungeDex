using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
    public interface IUserService
    {

        public List<User> getUsers();

        public User getuserByName(string name);
    }
}
