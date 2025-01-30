﻿using System.Net;
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
			var result = new Result<Pokemon>();

			try
			{
				using var httpClient = _httpClient;
				var response = await httpClient.GetAsync($"pokemon/{pokemonName}");
				response.EnsureSuccessStatusCode();
				var json = await response.Content.ReadAsStringAsync();
				var pokemon = ConvertJsonToPokemon(json);
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
				result.ErrorMessage = $"An error occurred while deserializing the PokéAPI response.";
			}

			return result;
		}

		private Pokemon ConvertJsonToPokemon(string json)
		{
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

			return pokemon;
		}
	}
}
