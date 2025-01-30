using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
	public interface IPokeApiRepository
	{
		Task<Result<Pokemon>> GetPokemon(string pokemonName);
	}
}
