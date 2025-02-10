namespace DungeDexFE.Client.Models
{
	public class User
	{
		public string Id { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public List<Dungemon> Dungemons = [];
	}
}
