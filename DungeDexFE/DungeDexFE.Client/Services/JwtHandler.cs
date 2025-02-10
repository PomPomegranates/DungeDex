using Blazored.SessionStorage;

namespace DungeDexFE.Client.Services
{
	public class JwtHandler : DelegatingHandler
	{
		private readonly ISessionStorageService _sessionStorage;

		public JwtHandler(ISessionStorageService sessionStorage)
		{
			_sessionStorage = sessionStorage;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
		{
			var token = await _sessionStorage.GetItemAsStringAsync("Jwt", cancellationToken);

			if (token != null) requestMessage.Headers.Add("Authorization", $"Bearer {token}");

			var response = await base.SendAsync(requestMessage, cancellationToken);

			return response;
		}
	}
}
