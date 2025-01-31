using DungeDexBE.Models;
using Microsoft.EntityFrameworkCore;
namespace DungeDexBE
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {
        }

        public DbSet<Monster> MonsterDb { get;set; }

    }
}
