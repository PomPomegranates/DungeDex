using DungeDexBE.Models;
using Newtonsoft.Json.Linq;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
	public interface IPokeApiRepository
	{
		Task<Result> GetPokemon(string pokemonName);
		Task<Pokemon> ConvertJsonToPokemon(string json);
		Task<JObject?> GetEquivalentSpecies(JObject jObj);


	}
}
