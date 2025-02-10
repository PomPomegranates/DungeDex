namespace DungeDexBE.Models
{
	public class MonsterAction
	{
		public int Id { get; set; }
		public int DungemonId { get; set; }
		public string Name { get; set; } = null!;//= string.Empty;
		public string Description { get; set; } = null!;//= string.Empty;
	}
}
