using System.ComponentModel.DataAnnotations;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DungeDexBE.Controllers
{
	[Route("api/[controller]")]
	[EnableCors("AllowLocalhost")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly IJwtService _jwtService;

		public AuthenticationController(UserManager<User> userManager, IJwtService jwtService)
		{
			_userManager = userManager;
			_jwtService = jwtService;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginModel model)
		{
			var user = await _userManager.FindByNameAsync(model.UserName);
			if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
			{
				var token = _jwtService.GenerateJwtToken(user);
				return Ok(new { token });
			}
			return Unauthorized();
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] LoginModel model)
		{
			var user = new User { UserName = model.UserName };
			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded) return Ok(new { Message = "Successfully registered!" });
			return BadRequest(result.Errors);
		}

		[HttpGet("currentUser")]
		public IActionResult GetCurrentUser()
		{
			try
			{
				var userId = _jwtService.ValidateUserIdFromJwt(Request);
				var userName = _jwtService.ValidateUserNameFromJwt(Request);

				if (userId is null || userName is null) return Unauthorized("Session token is missing or invalid.");

				return Ok(new { UserId = userId, UserName = userName });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Unauthorized("Invalid session token.");
			}
		}
	}

	public class LoginModel
	{
		[Required]
		public string UserName { get; set; } = null!;
		[Required]
		public string Password { get; set; } = null!;
	}
}