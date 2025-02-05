using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[ApiController]
	[EnableCors("AllowLocalhost")]
	[Route("api/[controller]")]
	public class UserDungeMonController : ControllerBase
	{
		private readonly IUserDungeMonService _userDungeMonService;

		public UserDungeMonController(IUserDungeMonService userDungeMonService)
		{
			_userDungeMonService = userDungeMonService;
		}

		[HttpGet]
		public IActionResult GetAllDungemon(
			[FromQuery] int number,
			[FromQuery] int offset,
			[FromQuery] string? basePokemon = null
		)
		{
			var dungemonFilterOptions = new DungemonFilterDto(basePokemon, number, offset);

			var result = _userDungeMonService.GetDungemon(dungemonFilterOptions);

			if (result is null) return BadRequest();

			if (result.Count == 0) return NotFound();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetDungemonById(int id)
		{
			var result = _userDungeMonService.GetDungemonById(id);

			if (result.Item1 != null) return Ok(result.Item1);

			if (result.Item2.Contains("No Userdata")) return NotFound(result.Item2);

			return BadRequest(result.Item2);

		}

		[HttpPost]
		public IActionResult PostUserDungemon(DungeMon monster)
		{
			var result = _userDungeMonService.AddDungemon(monster);

			if (result.Item2 == "Success")
				return CreatedAtAction("GetDungemonById", new { result.Item1!.Id }, result.Item1);

			return BadRequest((monster, result.Item2));
		}

		[HttpPatch]
		public IActionResult PatchUserDungemon(DungeMon dungemon)
		{
			var result = _userDungeMonService.UpdateDungemon(dungemon);

			if (result.Item2 == "Success") return Ok(result.Item1);

			return StatusCode(304, "Unable to update Dungemon.");
		}

		[HttpDelete]
		public IActionResult DeleteUserDungemon(int dungemonId)
		{
			var result = _userDungeMonService.DeleteDungemonById(dungemonId);

			if (result == "Success") return NoContent();

			return NotFound(result);
		}
	}
}
