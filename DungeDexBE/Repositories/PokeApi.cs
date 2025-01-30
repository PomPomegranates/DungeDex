namespace DungeDexBE.Repositories
{
	public class PokeApi
	{
		private readonly HttpClient _httpClient;

		public PokeApi(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("pokemon");
		}

		public async Task<string> GetPokemon()
		{
			using var httpClient = _httpClient;
			string result = await httpClient.GetStringAsync("pokemon/1");
			return result;
		}
	}
}
