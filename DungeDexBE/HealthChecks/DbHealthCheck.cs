using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace DungeDexBE.HealthChecks
{
	public class DbHealthCheck : IHealthCheck
	{
		public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			string directory = Directory.GetCurrentDirectory();
			directory += "/Secrets.json";
			var jObj = JObject.Parse(File.ReadAllText(directory));
			string connectionString = jObj["ConnectionStrings"]!["MyCnString"]!.ToString();

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();
					return Task.FromResult(HealthCheckResult.Healthy("A connection to the database was established."));
				}
				catch (Exception ex)
				{
					return Task.FromResult(HealthCheckResult.Unhealthy(ex.Message));
				}
			}
			
		}
	}
}
