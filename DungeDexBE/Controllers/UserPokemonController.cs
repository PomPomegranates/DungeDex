using DungeDexBE.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserPokemonController : ControllerBase
	{
		private readonly IUserPokemonsterService _userPokemonsterService;

		public UserPokemonController(IUserPokemonsterService userPokemonsterService)
		{
			_userPokemonsterService = userPokemonsterService;
		}

		[HttpGet]
		public IActionResult GetAllPokemon()
		{
			var result = _userPokemonsterService.GetMonsters();

			if (result != null && result.Count > 0)
			{
				return Ok(result);
			}
			else if (result is null)
			{
				return BadRequest();
			}
			else if (result.Count == 0)
			{
				return NotFound();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
