using DungeDexBE.HealthChecks;
using Newtonsoft.Json;

namespace DungeDexBE.Extensions
{
	public static class WebApplicationBuilderHttpExtensions
	{
		public static WebApplicationBuilder ConfigureHttpServices(this WebApplicationBuilder builder)
		{
			builder.AddCors();
			builder.AddHttpClients();
			builder.AddHealthChecks();
			return builder;
		}

		public static WebApplicationBuilder ConfigureControllers(this WebApplicationBuilder builder)
		{
			builder.Services.AddControllers().AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});

			return builder;
		}

		public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
		{
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowLocalhost",
					policy => policy.WithOrigins("https://localhost:7107")
									.AllowAnyMethod()
									.AllowAnyHeader());
			});

			return builder;
		}

		public static WebApplicationBuilder AddHttpClients(this WebApplicationBuilder builder)
		{
			builder.Services.AddHttpClient("pokemon", options =>
			{
				options.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
			});

			builder.Services.AddHttpClient("dnd", options =>
			{
				options.BaseAddress = new Uri("https://www.dnd5eapi.co/api/");
			});

			return builder;
		}

		public static WebApplicationBuilder AddHealthChecks(this WebApplicationBuilder builder)
		{
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
			return builder;
		}
	}
}
