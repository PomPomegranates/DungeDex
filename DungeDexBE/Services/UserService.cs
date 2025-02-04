using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Repositories;

namespace DungeDexBE.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) { 
        
            _userRepository = userRepository;

        }
        


        public List<User> getUsers()
        {

            return _userRepository.getUsers();

        }

        public User getuserByName(string name)
        {
            return _userRepository.getUserByName(name);
        }
    }
}
