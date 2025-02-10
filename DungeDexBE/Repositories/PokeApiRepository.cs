using System.Net;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;

namespace DungeDexBE.Repositories
{
	public class PokeApiRepository : IPokeApiRepository
	{
		private readonly IHttpClientFactory _httpClient;

		public PokeApiRepository(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory;
		}

		public async Task<Result> GetPokemon(string pokemonName)
		{
			var result = new Result();

			try
			{
				using var httpClient = _httpClient.CreateClient("pokemon");
				var response = await httpClient.GetAsync($"pokemon/{pokemonName}");
				response.EnsureSuccessStatusCode();
				var json = await response.Content.ReadAsStringAsync();
				var pokemon = await ConvertJsonToPokemon(json);
				result.Value = pokemon;
			}
			catch (HttpRequestException ex)
			{
				result.IsSuccess = false;
				result.StatusCode = ex.StatusCode!.Value;
				result.ErrorMessage = $"PokéAPI {ex.Message}";
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.StatusCode = HttpStatusCode.InternalServerError;
				result.ErrorMessage = $"An error occurred while deserializing the PokéAPI response: {ex.Message}";
			}

			return result;
		}

		public async Task<Pokemon> ConvertJsonToPokemon(string json)
		{
			var jObj = JObject.Parse(json);
			var pokemonStats = jObj["stats"]!.ToList();
			var pokemonTypes = jObj["types"]!.ToList();
			var pokemon = new Pokemon()
			{
				Name = jObj["name"]!.ToString(),
				HP = ((int)pokemonStats[0]!["base_stat"]!),
				Attack = ((int)pokemonStats[1]!["base_stat"]!),
				Defense = ((int)pokemonStats[2]!["base_stat"]!),
				SpecialAttack = ((int)pokemonStats[3]!["base_stat"]!),
				SpecialDefense = ((int)pokemonStats[4]!["base_stat"]!),
				Speed = ((int)pokemonStats[5]!["base_stat"]!),
				Type1 = pokemonTypes[0]!["type"]!["name"]!.ToString(),
				Cry = jObj!["cries"]!["latest"]!.Value<string>()!,
				pokemonId = (int)jObj["id"]!
			};

			if (pokemonTypes.Count == 2) pokemon.Type2 = pokemonTypes[1]["type"]!["name"]!.ToString();

			var speciesPageObj = await GetEquivalentSpecies(jObj);

			if (speciesPageObj != null)
			{
				pokemon.Shape = speciesPageObj["shape"]!["name"]!.ToString();
				if ((bool)speciesPageObj["is_legendary"]! || (bool)speciesPageObj["is_mythical"]!)
				{
					pokemon.IsLegendaryOrMythical = true;
				}
			}

			if (jObj["sprites"]!["other"]!["home"]!["front_default"] != null)
			{
				pokemon.ImageLink = jObj["sprites"]!["other"]!["home"]!["front_default"]!.Value<string>()!;
			}
			else
			{
				pokemon.ImageLink = jObj!["sprites"]!["front_default"]!.Value<string>()!;
			}

			

			return pokemon;
		}

		public async Task<JObject?> GetEquivalentSpecies(JObject jObj)
		{
			try
			{
				using var httpClient = new HttpClient();
				var response = await httpClient.GetAsync(jObj["species"]!["url"]!.ToString());
				response.EnsureSuccessStatusCode();
				var json = await response.Content.ReadAsStringAsync();
				var speciesObj = JObject.Parse(json);
				return speciesObj;

			}
			catch (Exception ex)
			{
				return null;
			}

		}

	}
}
