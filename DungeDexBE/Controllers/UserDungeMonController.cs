using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using Microsoft.AspNetCore.Mvc;
namespace DungeDexBE.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserDungeMonController : ControllerBase
	{
		private readonly IUserDungeMonService _userDungeMonService;

		public UserDungeMonController(IUserDungeMonService userDungeMonService)
		{
			_userDungeMonService = userDungeMonService;
		}

		[HttpGet]
		public IActionResult GetAllPokemon()
		{
			var result = _userDungeMonService.GetMonsters();

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

			var result = _userDungeMonService.GetSingularMonster(id);

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
<<<<<<< HEAD:DungeDexBE/Controllers/UserPokemonController.cs
		public IActionResult PostUserMonster(Monster monster)
=======
        public IActionResult PostUserMonster(DungeMon monster)
>>>>>>> main:DungeDexBE/Controllers/UserDungeMonController.cs
		{
			var result = _userDungeMonService.PostUserMonster(monster);

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
