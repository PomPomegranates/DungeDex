using DungeDexBE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<DungeMon> Dungemon { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Spell> Spells { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
