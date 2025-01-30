using DungeDexBE.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SpellsController : ControllerBase
	{
		private readonly IDNDService _service;
		public SpellsController(IDNDService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllSpellNamesAsync()
		{
			var result = await _service.GetAllSpellNamesAsync();

			if (result == null)
			{
				return BadRequest("There was an issue contacting the API.");
			}

			if (result.Count == 0)
			{
				return StatusCode(500, "There was an issue converting from JSON to SpellDTO.");
			}

			return Ok(result);

		}
	}
}
