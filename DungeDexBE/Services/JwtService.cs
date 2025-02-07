using DungeDexBE.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DungeDexBE.Services
{
	public class JwtService : IJwtService
	{
		private readonly IConfiguration _configuration;

		public JwtService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string? ValidateUserIdFromJwt(HttpRequest httpRequest)
		{
			return ValidateToken(httpRequest)?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
		}

		public string? ValidateUserNameFromJwt(HttpRequest httpRequest)
		{
			return ValidateToken(httpRequest)?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
		}

		public ClaimsPrincipal? ValidateToken(HttpRequest httpRequest)
		{
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

			var authorizationHeader = httpRequest.Headers["Authorization"].FirstOrDefault();

			if (string.IsNullOrEmpty(authorizationHeader)) return null;

			var token = authorizationHeader.StartsWith("Bearer ")
				? authorizationHeader.Substring(7)
				: authorizationHeader;

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

		public string GenerateJwtToken(IdentityUser user)
		{
			var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity([new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Sid, user.Id)]),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
