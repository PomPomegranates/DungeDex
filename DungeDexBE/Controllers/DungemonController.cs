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
	public class DungemonController : ControllerBase
	{
		private readonly IDungemonService _dungemonService;
		private readonly IJwtService _jwtService;

		public DungemonController(IDungemonService dungemonService, IJwtService jwtService)
		{
			_dungemonService = dungemonService;
			_jwtService = jwtService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDungemon(
			[FromQuery] int number,
			[FromQuery] int offset,
			[FromQuery] string? basePokemon = null
		)
		{
			var dungemonFilterOptions = new DungemonFilterDto(basePokemon, number, offset);

			var result = await _dungemonService.GetDungemon(dungemonFilterOptions);

			if (result is null) return BadRequest();

			if (result.Count == 0) return NotFound();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDungemonById(int id)
		{
			var result = await _dungemonService.GetDungemonById(id);

			if (result.Item1 != null) return Ok(result.Item1);

			if (result.Item2.Contains("No Userdata")) return NotFound(result.Item2);

			return BadRequest(result.Item2);
		}

		[HttpPost]
		public async Task<IActionResult> PostDungemon(Dungemon dungemon)
		{
			var jwtUserId = _jwtService.ValidateUserIdFromJwt(Request);

			if (string.IsNullOrEmpty(jwtUserId)) return Unauthorized("You must be signed-in to publish Dungémon.");

			dungemon.UserId = jwtUserId;

			var result = await _dungemonService.AddDungemon(dungemon);

			if (result.Item2 == "Success")
				return CreatedAtAction("GetDungemonById", new { result.Item1!.Id }, result.Item1);

			return BadRequest((dungemon, result.Item2));
		}

		[HttpPatch]
		public async Task<IActionResult> PatchDungemon(Dungemon dungemon)
		{
			var jwtUserId = _jwtService.ValidateUserIdFromJwt(Request);

			if (string.IsNullOrEmpty(jwtUserId) || dungemon.UserId != jwtUserId) return Unauthorized("You may not edit other users' Dungémon.");

			var result = await _dungemonService.UpdateDungemon(dungemon);

			if (result.Item2 == "Success") return Ok(result.Item1);

			return StatusCode(304, "Unable to update Dungemon.");
		}

		[HttpDelete("{dungemonId}")]
		public async Task<IActionResult> DeleteDungemon(int dungemonId)
		{
			var jwtUserId = _jwtService.ValidateUserIdFromJwt(Request);

			if (string.IsNullOrEmpty(jwtUserId)) return Unauthorized("You must be signed-in to delete a Dungémon.");

			var result = await _dungemonService.DeleteDungemonById(dungemonId, jwtUserId);

			if (result == "Success") return NoContent();

			return NotFound(result);
		}
	}
}
