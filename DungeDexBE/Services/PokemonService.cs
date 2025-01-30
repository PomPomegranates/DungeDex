using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;

namespace DungeDexBE.Services
{
	public class PokemonService : IPokemonService
	{
		private readonly IPokeApiRepository _pokeApiRepository;

		public PokemonService(IPokeApiRepository pokeApiRepository)
		{
			_pokeApiRepository = pokeApiRepository;
		}

		public async Task<Result<Pokemon>> GetBasePokemonAsync(string pokemonName)
		{
			return await _pokeApiRepository.GetPokemon(pokemonName);
		}
	}
}
