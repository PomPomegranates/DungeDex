using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Models
{
	[Index(nameof(UserName), IsUnique = true)]
	public class User
	{
		public int Id { get; set; }
		public string UserName { get; set; } = null!;
		public virtual List<DungeMon> DungeMons { get; set; } = [];
	}
}

