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
    }
}
