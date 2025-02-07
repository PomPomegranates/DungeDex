using Blazored.SessionStorage;
using DungeDexFE.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DungeDexFE.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.Services.AddAuthorizationCore();
			builder.Services.AddScoped<AuthStateProvider>();
			builder.Services.AddBlazoredSessionStorageAsSingleton();
			builder.Services.AddScoped<JwtHandler>();
			builder.Services
				.AddHttpClient("BackendAPI", client => client.BaseAddress = new Uri("https://localhost:7298/api/"))
				.AddHttpMessageHandler<JwtHandler>();

			await builder.Build().RunAsync();
		}
	}
}
