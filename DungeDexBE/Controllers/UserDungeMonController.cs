using DungeDexBE.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using DungeDexBE.Models;
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

			} else
			{
				return BadRequest(result.Item2);
			}
		}

		[HttpPost]
        public IActionResult PostUserMonster(Monster monster)
		{
			var result = _userDungeMonService.PostUserMonster(monster);

			if (result.Item2 == "Success")
			{
				return Created();
			}
			else
			{
				return BadRequest((monster,result.Item2));
			}
		}

    }
}
