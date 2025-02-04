using System.Net;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;
using Newtonsoft.Json.Linq;

namespace DungeDexBE.Repositories
{
	public class DNDApiRepository : IDNDApiRepository
	{
		private readonly IHttpClientFactory _httpClient;

		public DNDApiRepository(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory;
		}
		public async Task<Dictionary<string, string>?> GetAllSpellsNamesAsync()
		{
			Dictionary<string, string> result = new();

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


			}
			catch (Exception ex)
			{

			}

			return result;
		}

		public async Task<Result> GetSpellByNameOrIndex(string nameOrIndex)
		{
			var allSpells = await GetAllSpellsNamesAsync();
			Result result = new Result();

			foreach (var keyValuePair in allSpells)
			{
				try
				{
					if (keyValuePair.Key == nameOrIndex || keyValuePair.Value == nameOrIndex)
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
