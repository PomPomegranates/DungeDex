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
        


        public List<User>? GetUsers()
        {

            return _userRepository.GetUsers();

        }

        public User? GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }

        public (User, string) PostUser(User newUser)
        {
            return _userRepository.PostUser(newUser);
        }

        //public List<DungeMon> GetUsersDungeMon(string name)
        //{
        //    _userRepository.GetUserByName(name)
        //}


    }
}
