using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DungeDexFE.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.Services.AddAuthorizationCore();
			builder.Services.AddCascadingAuthenticationState();
			builder.Services.AddAuthenticationStateDeserialization();
			builder.Services.AddBlazoredSessionStorageAsSingleton();

			await builder.Build().RunAsync();
		}
	}
}
