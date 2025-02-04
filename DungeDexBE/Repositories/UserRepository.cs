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

        public List<User>? getUsers()
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

        public User? getUserByName(string name)
        {

            try
            {
                return getUsers().Where(U => U.UserName == name).FirstOrDefault();

            }
            catch
            {
                return null;
            }
        }



    }
}
