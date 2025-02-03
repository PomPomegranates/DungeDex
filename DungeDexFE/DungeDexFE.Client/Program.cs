using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using DungeDexFE.Client.Services;

namespace DungeDexFE.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.Services.AddAuthorizationCore();
			builder.Services.AddCascadingAuthenticationState();
			builder.Services.AddSingleton<AuthenticationStateProvider, CustomAuthStateProvider>();
			builder.Services.AddSingleton<CustomAuthenticationService>();

			await builder.Build().RunAsync();
		}
	}
}
