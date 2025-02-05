using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DungeDexBE.HealthChecks
{
	public class DnDAPIHealthCheck : IHealthCheck
	{
		public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			using (HttpClient http = new HttpClient())
			{
				var response = await http.GetAsync("https://www.dnd5eapi.co/api/");
				try
				{
					response.EnsureSuccessStatusCode();
					return HealthCheckResult.Healthy("The DnD API is responding.");
				}
				catch (HttpRequestException hex)
				{
					return HealthCheckResult.Unhealthy("The DnD API is not responding: " + hex.Message);
				}
				catch (Exception ex)
				{
					return HealthCheckResult.Unhealthy(ex.Message);
				}
			}
		}
	}
}
