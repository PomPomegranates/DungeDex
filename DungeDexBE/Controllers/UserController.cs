using DungeDexBE.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[ApiController]
	[Authorize]
	[EnableCors("AllowLocalhost")]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult GetUsers()
		{
			var result = _userService.GetUsers();

			if (result is null) return BadRequest();

			if (result.Count == 0) return NotFound();

			return Ok(result);
		}

		[HttpGet("{name}")]
		public IActionResult GetUserByName(string name)
		{
			var result = _userService.GetUserByName(name);

			if (result != null) return Ok(result);

			return NotFound();
		}
	}
}
