using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        public List<User>? getUsers();

    }
}
