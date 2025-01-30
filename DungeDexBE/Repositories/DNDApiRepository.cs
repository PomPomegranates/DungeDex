using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Models;

namespace DungeDexBE.Repositories
{
    public class DNDApiRepository : IDNDApiRepository
    {
        private readonly IHttpClientFactory _httpClient;

        public DNDApiRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }
        public async Task<Dictionary<string, string>> GetAllSpellsNamesAsync()
        {
            Dictionary<string, string> result = new();

            var http = _httpClient.CreateClient("dnd");

            List<SpellDTO> allSpells = await http.GetFromJsonAsync<List<SpellDTO>>("spells");

            foreach (SpellDTO spellWrapper in allSpells)
            {
                result.Add(spellWrapper.Name, spellWrapper.Index);
            }

            return result;
        }
    }
}
