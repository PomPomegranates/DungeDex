using DungeDexBE.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PokemonController : ControllerBase
	{
		private readonly PokeApiRepository _pokeApi;

		public PokemonController(PokeApiRepository pokeApi)
		{
			_pokeApi = pokeApi;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{

		}
	}
}
