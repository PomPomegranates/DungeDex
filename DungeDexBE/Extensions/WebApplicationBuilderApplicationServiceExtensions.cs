using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Repositories;
using DungeDexBE.Services;

namespace DungeDexBE.Extensions
{
	public static class WebApplicationBuilderApplicationServiceExtensions
	{
		public static WebApplicationBuilder ConfigureApplicationServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddTransient<IJwtService, JwtService>();
			builder.Services.AddScoped<IPokeApiRepository, PokeApiRepository>();
			builder.Services.AddScoped<IPokemonService, PokemonService>();
			builder.Services.AddScoped<IDNDApiRepository, DNDApiRepository>();
			builder.Services.AddScoped<IDNDService, DNDService>();
			builder.Services.AddScoped<IUserDungemonRepository, UserDungemonRepository>();
			builder.Services.AddScoped<IDungemonService, DungemonService>();
			return builder;
		}
	}
}
