using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[ApiController]
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

		[HttpPost]
		public IActionResult PostUser(User newUser)
		{
			var result = _userService.PostUser(newUser);

			if (result.Item2 == "Success") return Created($"api/User/{newUser.UserName}", newUser);

			return BadRequest(result.Item1);
		}
	}
}
