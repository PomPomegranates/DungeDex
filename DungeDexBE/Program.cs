using System.Text;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Persistence;
using DungeDexBE.Repositories;
using DungeDexBE.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowLocalhost",
					policy => policy.WithOrigins("https://localhost:7107")
									.AllowAnyMethod()
									.AllowAnyHeader());
			});

			// NEW
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

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseCors("AllowLocalhost");

			// NEW
			app.UseAuthentication();
			// END
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
