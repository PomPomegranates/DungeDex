using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DungeDexBE.HealthChecks
{
	public class PokeAPIHealthCheck : IHealthCheck
	{
		public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			using (HttpClient http = new HttpClient())
			{
				var response = await http.GetAsync("https://pokeapi.co/api/v2/pokemon/ditto");
				try
				{
					response.EnsureSuccessStatusCode();
					return HealthCheckResult.Healthy("The Pokémon API is responding.");
				}
				catch (HttpRequestException hex)
				{
					return HealthCheckResult.Unhealthy("The Pokémon API is not responding: " + hex.Message);
				}
				catch (Exception ex)
				{
					return HealthCheckResult.Unhealthy(ex.Message);
				}
			}
		}
	}
}
