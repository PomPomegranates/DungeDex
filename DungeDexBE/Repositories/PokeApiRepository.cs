using DungeDexBE.Interfaces;

namespace DungeDexBE.Repositories
{
	public class PokeApiRepository : IPokeApiRepository
	{
		private readonly HttpClient _httpClient;

		public PokeApiRepository(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("pokemon");
		}

		public async Task<string> GetPokemon(string pokemonName)
		{
			using var httpClient = _httpClient;
			var result = await httpClient.GetAsync($"pokemon/{pokemonName}");

			if (!result.IsSuccessStatusCode) return null;

			return result;
		}
	}
}
