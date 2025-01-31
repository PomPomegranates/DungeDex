using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Repositories;
using DungeDexBE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddHttpClient("pokemon", options =>
			{
				options.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
			});
			builder.Services.AddHttpClient("dnd", options =>
			{
				options.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");
			});

			builder.Services.AddScoped<IPokeApiRepository, PokeApiRepository>();
			builder.Services.AddScoped<IPokemonService, PokemonService>();
			builder.Services.AddScoped<IDNDApiRepository, DNDApiRepository>();
			builder.Services.AddScoped<IDNDService, DNDService>();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


            var cnn = new SqliteConnection("Filename=:memory:");
            cnn.Open();
			builder.Services.AddDbContext<MyDbContext>(o => o.UseSqlite(cnn));



            var app = builder.Build();
			AddData(app);	
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}

		static void AddData(WebApplication app)
		{
			var scope = app.Services.CreateScope();
			var db = scope.ServiceProvider.GetService<MyDbContext>();

			db.Database.EnsureDeleted();
			db.Database.EnsureCreated();

			var Monster = new Monster
			{
				Id = 1,
				UserId = 1,
				Name = "Jim",
				ChallengeRating = 12,
				ArmorClass = 12,
				Attributes = new Attributes { Strength = 1, Dexterity = 1,Constitution = 1, Intelligence = 1,Wisdom = 1,Charisma = 1},
				HitPoints = 12,
				Spells = new List<Spell>
				{
					new Spell{Id = 1, Name = "boom", Description = "big boom", MonsterId = 1}
				},
				ImageLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/shiny/186.png"
			};
			
			db.MonsterDb.Add(Monster);
			db.SaveChanges();
        }
    }
}
