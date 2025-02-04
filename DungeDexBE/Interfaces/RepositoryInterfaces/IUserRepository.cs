using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public List<User>? getUsers();


        public User? getUserByName(string name);
    }
}
