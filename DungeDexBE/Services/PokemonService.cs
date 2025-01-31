using System.Net;
using DungeDexBE.ConversionFunctions;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;

namespace DungeDexBE.Services
{
	public class PokemonService : IPokemonService
	{
		private readonly IPokeApiRepository _pokeApiRepository;
		private readonly IDNDApiRepository _dndApiRepository;

		public PokemonService(IPokeApiRepository pokeApiRepository, IDNDApiRepository dndApiRepository)
		{
			_pokeApiRepository = pokeApiRepository;
			_dndApiRepository = dndApiRepository;
		}

		public async Task<Result> GetBasePokemonAsync(string pokemonName)
		{
			return await _pokeApiRepository.GetPokemon(pokemonName);
		}

		public async Task<Result> GetMonsterByPokemonAsync(string pokemonName)
		{
			var result = await GetBasePokemonAsync(pokemonName);

			if (!result.IsSuccess) return result;

			try
			{
				var pokemon = result.Value as Pokemon;
				Monster monster = pokemon!.ToMonster();
				var spellResult = await _dndApiRepository.GetRandomSpell();
				monster.Spells.Add(spellResult.Value as Spell);
				result.Value = monster;
			}
			catch (Exception ex)
			{
				result.IsSuccess = false;
				result.ErrorMessage = $"An error occurred while converting the pokemon to monster. Error: {ex.Message}";
				result.StatusCode = HttpStatusCode.InternalServerError;
			}

			return result;
		}
	}
}
