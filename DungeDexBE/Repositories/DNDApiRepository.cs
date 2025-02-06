using System.Net;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace DungeDexBE.Repositories
{
	public class DNDApiRepository : IDNDApiRepository
	{
		private readonly IHttpClientFactory _httpClient;
		private readonly IMemoryCache _cache;

		public DNDApiRepository(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
		{
			_httpClient = httpClientFactory;
			_cache = memoryCache;
		}
		public async Task<Dictionary<string, string>?> GetAllSpellsNamesAsync()
		{


			if (!_cache.TryGetValue("AllSpells", out Dictionary<string, string> result))
			{
				result = new();
				var http = _httpClient.CreateClient("dnd");

				var httpResult = await http.GetAsync("spells");

				if (!httpResult.IsSuccessStatusCode) return null;

				try
				{
					string json = await httpResult.Content.ReadAsStringAsync();

					JObject jsonResult = JObject.Parse(json);

					var allJSpells = jsonResult["results"].ToList();


					foreach (var jSpell in allJSpells)
					{
						string name = jSpell["name"].Value<string>();
						string index = jSpell["index"].Value<string>();
						result.Add(name, index);
					}
					var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));

					_cache.Set("AllSpells", result, cacheEntryOptions);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			return result;
		}

		public async Task<Result> GetSpellByNameOrIndex(string index)
		{
			var allSpells = await GetAllSpellsNamesAsync();
			Result result = new Result();

			foreach (var keyValuePair in allSpells)
			{
				try
				{
					if (keyValuePair.Key == index || keyValuePair.Value == index)
					{
						var http = _httpClient.CreateClient("dnd");

						var httpResult = await http.GetAsync($"spells/{keyValuePair.Value}");

						var json = await httpResult.Content.ReadAsStringAsync();
						httpResult.EnsureSuccessStatusCode();

						Spell spell = ConvertJsonToSpell(json);

						result.Value = spell;

					}
				}
				catch (HttpRequestException ex)
				{
					result.IsSuccess = false;
					result.StatusCode = ex.StatusCode!.Value;
					result.ErrorMessage = $"DnDAPI {ex.Message}";
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					result.IsSuccess = false;
					result.StatusCode = HttpStatusCode.InternalServerError;
					result.ErrorMessage = $"An error occurred while deserializing the DnDAPI response.";
				}
			}
			return result;

		}

		public Spell ConvertJsonToSpell(string json)
		{
			Spell spell = new Spell();

			JObject jObj = JObject.Parse(json);

			spell.Name = jObj["name"]!.Value<string>()!;


			spell.Description = jObj["desc"]![0]!.Value<string>()!;


			return spell;
		}

		public async Task<Result> GetRandomSpell()
		{
			var allSpells = await GetAllSpellsNamesAsync();

			Random random = new Random();

			int randomIndex = random.Next(allSpells.Count);

			Result result = await GetSpellByNameOrIndex(allSpells.ElementAt(randomIndex).Value);

			return result;
		}
	}
}
