using System.Text;
using DungeDexBE.HealthChecks;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Persistence;
using DungeDexBE.Repositories;
using DungeDexBE.Services;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DungeDexBE
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers().AddNewtonsoftJson(options =>
			{
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

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowLocalhost",
					policy => policy.WithOrigins("https://localhost:7107")
									.AllowAnyMethod()
									.AllowAnyHeader());
			});
            builder.Services.AddHealthChecks()
                .AddCheck<DnDAPIHealthCheck>("DnD API Status Check",
                                            failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy,
                                            tags: new[] { "api" })
                .AddCheck<PokeAPIHealthCheck>("PokéAPI Status Check",
                                            failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy,
                                            tags: new[] { "api" })
                .AddCheck<DbHealthCheck>("Database Connection Check",
                                        failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy,
                                        tags: new[] { "database" });

			// NEW
			builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Secrets.json");
			builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();
			var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});
			builder.Services.AddAuthorization();
			// END

			builder.Services.AddScoped<IPokeApiRepository, PokeApiRepository>();
			builder.Services.AddScoped<IPokemonService, PokemonService>();
			builder.Services.AddScoped<IDNDApiRepository, DNDApiRepository>();
			builder.Services.AddScoped<IDNDService, DNDService>();
			builder.Services.AddScoped<IUserDungeMonRepository, UserDungeMonRepository>();
			builder.Services.AddScoped<IUserDungeMonService, UserDungeMonService>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IUserService, UserService>();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			builder.Services.AddDbContext<ApplicationDbContext>(o =>
			{
				o.UseSqlServer(builder.Configuration.GetConnectionString("MyCnString"));
			});

            builder.Services.AddMemoryCache();
			builder.Services.AddResponseCaching();

            var app = builder.Build();

			AddData(app);

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseCors("AllowLocalhost");
			app.UseResponseCaching();
			app.UseAuthorization();

            app.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

			app.MapControllers();

			app.Run();
		}

		static void AddData(WebApplication app)
		{
			var scope = app.Services.CreateScope();
			var db = scope.ServiceProvider.GetService<ApplicationDbContext>();



			db.Database.EnsureDeleted();
			db.Database.EnsureCreated();


			var user = new User
			{
				UserName = "Testina"


			};
			var user2 = new User
			{
				UserName = "John Doe"


			};

			var spell = new Spell
			{
				Name = "Goodberry",
				Description = "Up to ten berries appear in your hand and are infused with magic for the duration. A creature can use its action to eat one berry. Eating a berry restores 1 hit point, and the berry provides enough nourishment to sustain a creature for a day."

			};

			var spell2 = new Spell
			{
				Name = "Sunbeam",
				Description = "A beam of brilliant light flashes out fro m your hand in a 5-foot-wide, 60-foot-long line. Each creature in the line must make a constitution saving throw. On a failed save, a creature takes 6d8 radiant damage and is blinded until your next turn. On a successful save, it takes half as much damage and isn't blinded by this spell. Undead and oozes have disadvantage on this saving throw."
			};

			var spell3 = new Spell
			{
				Name = "Acid Splash",
				Description = "You hurl a bubble of acid. Choose one creature within range, or choose two creatures within range that are within 5 feet of each other. A target must succeed on a dexterity saving throw or take 1d6 acid damage."
			};


			var monster = new Dungemon
			{

				BasePokemon = "Lilligant",
				NickName = "Lilly",
				User = user,
				ChallengeRating = 12,
				ArmorClass = 12,
				HitPoints = 100,
				Strength = 14,
				Constitution = 13,
				Wisdom = 14,
				Intelligence = 12,
				Dexterity = 18,
				Charisma = 9,
				Spells = new List<Spell>
				{
					spell,
					spell3
				},
				ImageLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/shiny/186.png"
			};

			var monster2 = new Dungemon
			{

				BasePokemon = "Venusaur",
				NickName = "Jimmy",
				User = user,
				ChallengeRating = 12,
				ArmorClass = 12,
				HitPoints = 100,
				Strength = 14,
				Constitution = 13,
				Wisdom = 14,
				Intelligence = 12,
				Dexterity = 18,
				Charisma = 9,
				Spells = new List<Spell>
				{
					spell,
					spell2
				},
				ImageLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/shiny/186.png"
			};
			var monster3 = new Dungemon
			{

				BasePokemon = "Bayleaf",
				NickName = "Baybeee",
				User = user2,
				ChallengeRating = 12,
				ArmorClass = 12,
				HitPoints = 100,
				Strength = 14,
				Constitution = 13,
				Wisdom = 14,
				Intelligence = 12,
				Dexterity = 18,
				Charisma = 9,
				Spells = new List<Spell>
				{
					spell2,
					spell3
				},
				ImageLink = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/shiny/186.png"
			};


			db.Dungemon.Add(monster);
			db.Dungemon.Add(monster2);
			db.Dungemon.Add(monster3);

			db.SaveChanges();
		}
	}

}
