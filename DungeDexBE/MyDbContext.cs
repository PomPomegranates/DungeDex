using DungeDexBE.Models;
using Microsoft.EntityFrameworkCore;
namespace DungeDexBE
{
    public class MyDbContext :DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Monster>()
            //    .HasMany(e => e.Spells)
            //    .WithOne(e => e.Monster)
            //    .HasForeignKey(e => e.MonsterId)
            //    .IsRequired();
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DungeMon>()
                .HasMany(e => e.Spells)
                .WithMany(e => e.Monsters);

        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseLazyLoadingProxies();
		}
		public DbSet<DungeMon> MonsterDb { get;set; }
        public DbSet<Spell> SpellTable { get;set; }    
    }
}
