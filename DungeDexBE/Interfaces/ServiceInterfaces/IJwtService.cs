using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
	public interface IJwtService
	{
		string GenerateJwtToken(IdentityUser user);
		string? ValidateUserIdFromJwt(HttpRequest httpRequest);
		string? ValidateUserNameFromJwt(HttpRequest httpRequest);
		ClaimsPrincipal? ValidateToken(HttpRequest token);
	}
}