using DungeDexBE.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[ApiController]
	[AllowAnonymous]
	[EnableCors("AllowLocalhost")]
	[Route("api/[controller]")]
	public class PokemonController : ControllerBase
	{
		private readonly IPokemonService _pokemonService;

		public PokemonController(IPokemonService pokemonService)
		{
			_pokemonService = pokemonService;
		}

		[HttpGet("{pokemonNameOrId}")]
		public async Task<IActionResult> GetBasePokemon(string pokemonNameOrId)
		{
			var result = await _pokemonService.GetBasePokemonAsync(pokemonNameOrId);

			if (result.IsSuccess) return Ok(result.Value);

			return StatusCode((int)result.StatusCode!, result.ErrorMessage);
		}

		[HttpGet("{pokemonNameOrId}/monsterify")]
		public async Task<IActionResult> GetMonsterFromPokemon(string pokemonNameOrId)
		{
			var result = await _pokemonService.GetDungemonFromPokemonAsync(pokemonNameOrId);

			if (result.IsSuccess) return Ok(result.Value);

			return StatusCode((int)result.StatusCode!, result.ErrorMessage);
		}
	}
}
