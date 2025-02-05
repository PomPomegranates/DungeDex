using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DungeDexBE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DungeDexBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly IConfiguration _configuration;

		public AuthenticationController(UserManager<User> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_configuration = configuration;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginModel model)
		{
			var user = await _userManager.FindByNameAsync(model.UserName);
			if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
			{
				var token = GenerateJwtToken(user);
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
			var authorizationHeader = Request.Headers["Authorization"].FirstOrDefault();

			if (string.IsNullOrEmpty(authorizationHeader)) return Unauthorized("No session token provided.");

			var token = authorizationHeader.StartsWith("Bearer ")
				? authorizationHeader.Substring(7)
				: authorizationHeader;

			try
			{
				var principal = ValidateToken(token);

				var username = principal.Identity?.Name;

				return Ok(new { Username = username });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Unauthorized("Invalid session token.");
			}
		}

		private ClaimsPrincipal ValidateToken(string token)
		{
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
			var tokenHandler = new JwtSecurityTokenHandler();

			var validationParameters = new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateLifetime = true,
				IssuerSigningKey = new SymmetricSecurityKey(key)
			};

			var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

			return principal;
		}

		private string GenerateJwtToken(IdentityUser user)
		{
			var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity([new Claim(ClaimTypes.Name, user.UserName)]),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
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