using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Repositories;
using DungeDexBE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace DungeDexBE
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
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
			builder.Services.AddScoped<IUserPokemonsterRepository, UserPokemonsterRepository>();
			builder.Services.AddScoped<IUserPokemonsterService, UserPokemonsterService>();

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

			var spell = new Spell
			{
				Id = 1,
				MonsterId = 1,
				Name = "Boom",
				Description = "Big Boom"
			};


			var Monster = new Monster
			{
				Id = 1,
				UserId = 1,
				Name = "Jim",
				ChallengeRating = 12,
				ArmorClass = 12,
                HitPoints = 1,
				Strength = 3,
				Constitution = 3,
				Wisdom = 3,
				Intelligence = 3,
				Dexterity = 3,
				Charisma = 3,
				
				ImageLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/shiny/186.png"
			};
			
			db.MonsterDb.Add(Monster);
			db.SpellTable.Add(spell);

		

		



            //db.AttributesDb.Add(attributeDB);
            db.SaveChanges();
        }
    }
}
