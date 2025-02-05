using Microsoft.AspNetCore.Identity;

namespace DungeDexBE.Models
{
	public class User : IdentityUser
	{
		public ICollection<Dungemon> Dungemon { get; set; } = [];
	}
}

