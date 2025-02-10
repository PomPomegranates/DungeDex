using DungeDexBE.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace DungeDexBE
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.ConfigureHttpServices();
			builder.ConfigureIdentityAndDatabase();
			builder.ConfigureApplicationServices();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddAuthorization();
			builder.Services.AddMemoryCache();
			builder.Services.AddResponseCaching();
			builder.Services.AddControllers().AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
			});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				await app.SeedDatabase();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseCors("AllowLocalhost");
			app.UseResponseCaching();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseHealthChecks("/health", new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

			app.MapControllers();

			app.Run();
		}
	}
}
