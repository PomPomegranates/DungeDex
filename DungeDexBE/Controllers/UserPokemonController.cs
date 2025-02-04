using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
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
		[HttpGet("{id}")]
		public IActionResult GetPokemonById(int id)
		{

			var result = _userPokemonsterService.GetSingularMonster(id);

			if (result.Item1 != null)
			{
				return Ok(result.Item1);
			}
			else if (result.Item2.Contains("No Userdata"))
			{
				return NotFound(result.Item2);

			}
			else
			{
				return BadRequest(result.Item2);
			}
		}

		[HttpPost]
		public IActionResult PostUserMonster(Monster monster)
		{
			var result = _userPokemonsterService.PostUserMonster(monster);

			if (result.Item2 == "Success")
			{
				return CreatedAtAction("GetPokemonById", new { result.Item1.Id }, result.Item1);
			}
			else
			{
				return BadRequest((monster, result.Item2));
			}
		}

	}
}
