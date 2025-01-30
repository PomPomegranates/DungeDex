using DungeDexBE.Enums;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using Newtonsoft.Json.Linq;

namespace DungeDexBE.Repositories
{
	public class PokeApiRepository : IPokeApiRepository
	{
		private readonly HttpClient _httpClient;

		public PokeApiRepository(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("pokemon");
		}

		public async Task<Result<Pokemon>> GetPokemon(string pokemonName)
		{
			using var httpClient = _httpClient;
			var response = await httpClient.GetAsync($"pokemon/{pokemonName}");
			var result = new Result<Pokemon>();

			if (!response.IsSuccessStatusCode)
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				result.Outcome = Outcome.Failure;
				result.ErrorMessage = $"An error occurred while contacting PokéAPI. Error: {errorMessage}.";
				return result;
			}

			var json = await response.Content.ReadAsStringAsync();
			var jObj = JObject.Parse(json);
			var pokemonStats = jObj["stats"]!.ToList();
			var pokemon = new Pokemon()
			{
				Name = jObj["name"]!.ToString(),
				HP = ((int)pokemonStats[0]!["base_stat"]!),
				Attack = ((int)pokemonStats[1]!["base_stat"]!),
				Defense = ((int)pokemonStats[2]!["base_stat"]!),
				SpecialAttack = ((int)pokemonStats[3]!["base_stat"]!),
				SpecialDefense = ((int)pokemonStats[4]!["base_stat"]!),
				Speed = ((int)pokemonStats[5]!["base_stat"]!)
			};

			result.Value = pokemon;
			return result;
		}
	}
}
