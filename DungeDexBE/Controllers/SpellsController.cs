using DungeDexBE.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[ApiController]
	[EnableCors("AllowLocalhost")]
	[Route("api/[controller]")]
	public class SpellsController : ControllerBase
	{
		private readonly IDNDService _service;

		public SpellsController(IDNDService service)
		{
			_service = service;
		}

		[HttpGet]
		[ResponseCache(Location = ResponseCacheLocation.Any, NoStore =false, Duration = 604800)]
		public async Task<IActionResult> GetAllSpellNamesAsync()
		{
			Console.WriteLine("ControllerCache is empty");
			var result = await _service.GetAllSpellNamesAsync();

			if (result == null) return BadRequest("There was an issue contacting the API.");

			if (result.Count == 0) return StatusCode(500, "There was an issue converting from JSON to SpellDTO.");

			return Ok(result);
		}

		[HttpGet("{nameOrIndex}")]
		public async Task<IActionResult> GetSpellByNameOrIndex(string nameOrIndex)
		{
			var result = await _service.GetSpellByNameOrIndex(nameOrIndex);

			if (result.IsSuccess) return Ok(result.Value);

			return StatusCode((int)result.StatusCode!, result.ErrorMessage);
		}
	}
}
