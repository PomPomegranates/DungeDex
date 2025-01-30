using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
	public interface IPokeApiRepository
	{
		Task<Result> GetPokemon(string pokemonName);
	}
}
