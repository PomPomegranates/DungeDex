using DungeDexBE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Persistence
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public DbSet<Dungemon> Dungemon { get; set; }
		public DbSet<Spell> Spells { get; set; }
		public DbSet<Models.MonsterAction> Actions { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>(entity =>
			{
				entity.HasMany(u => u.Dungemon).WithOne(d => d.User).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Cascade);
			});

			builder.Entity<Dungemon>(entity =>
			{
				entity.Property(d => d.Id).ValueGeneratedOnAdd();
				entity.HasKey(d => d.Id);
				entity.HasMany(d => d.Spells).WithOne().HasForeignKey(s => s.DungemonId);
				entity.HasMany(d => d.Actions).WithOne().HasForeignKey(s => s.DungemonId);
				entity.Property(d => d.HitPoints).IsRequired();
				entity.Property(d => d.Strength).IsRequired();
				entity.Property(d => d.Constitution).IsRequired();
				entity.Property(d => d.Intelligence).IsRequired();
				entity.Property(d => d.Dexterity).IsRequired();
				entity.Property(d => d.Wisdom).IsRequired();
				entity.Property(d => d.Charisma).IsRequired();
				entity.Property(d => d.ArmorClass).IsRequired();
				entity.Property(d => d.BasePokemon).IsRequired();
				entity.Property(d => d.ChallengeRating).IsRequired();
				entity.Property(d => d.ImageLink).IsRequired();
				entity.Property(d => d.NickName).IsRequired();
				entity.Property(d => d.UserId).IsRequired();
				entity.HasOne(d => d.User).WithMany(u => u.Dungemon).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.NoAction);
			});

			builder.Entity<Spell>(entity =>
			{
				entity.Property(s => s.Id).ValueGeneratedOnAdd();
				entity.HasKey(s => s.Id);
				entity.Property(s => s.Name).IsRequired();
				entity.Property(s => s.Description).IsRequired();
				entity.Property(s => s.DungemonId).IsRequired();
			});

			base.OnModelCreating(builder);
		}
	}
}
