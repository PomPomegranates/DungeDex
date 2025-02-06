using System.Security.Claims;
using DungeDexFE.Client.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace DungeDexFE.Client.Services
{
	public class AuthStateProvider : AuthenticationStateProvider
	{
		private ClaimsPrincipal _currentUser;

		public AuthStateProvider()
		{
			_currentUser = GetAnonymous();
		}

		public override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			return Task.FromResult(new AuthenticationState(_currentUser));
		}

		public async Task<AuthenticationState> ChangeUserAsync(UserClaims userClaims)
		{
			_currentUser = GetUser(userClaims);
			var task = GetAuthenticationStateAsync();
			NotifyAuthenticationStateChanged(task);
			return await task;
		}

		public async Task<AuthenticationState> Logout()
		{
			_currentUser = GetAnonymous();
			var task = GetAuthenticationStateAsync();
			NotifyAuthenticationStateChanged(task);
			return await task;
		}

		public string? GetUserId()
		{
			var claim = _currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
			return claim != null ? claim.Value : null;
		}

		public string? GetUserName()
		{
			var claim = _currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
			return claim != null ? claim.Value : null;
		}

		private ClaimsPrincipal GetUser(UserClaims userClaims)
		{
			var identity = new ClaimsIdentity(new[]
			{
				new Claim(ClaimTypes.Sid, userClaims.UserId),
				new Claim(ClaimTypes.Name, userClaims.UserName)
			}, "Jwt");
			return new ClaimsPrincipal(identity);
		}

		private ClaimsPrincipal GetAnonymous()
		{
			var identity = new ClaimsIdentity(new[]
			{
				new Claim(ClaimTypes.Sid, "0"),
				new Claim(ClaimTypes.Name, "Anonymous"),
				new Claim(ClaimTypes.Role, "Anonymous")
			}, null);
			return new ClaimsPrincipal(identity);
		}
	}
}
