using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
	public interface IPokemonService
	{
		Task<Result<Pokemon>> GetBasePokemonAsync(string pokemonName);
	}
}
