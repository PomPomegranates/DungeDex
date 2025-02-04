using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;

namespace DungeDexBE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext myDbContext;

        public UserRepository(MyDbContext db)
        {
            myDbContext = db;
        }

        public List<User>? getUsers()
        {
            //get all users
            try
            {
                return myDbContext.Users.ToList();
            }
            catch
            {
                return null;
            }
        }



    }
}
