using System.Text.Json.Serialization;

namespace DungeDexFE.Client.Models
{
	public class MonsterAction
	{
		public int Id { get; set; }
		public int DungemonId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
		public Guid ClientId =  Guid.NewGuid();

		public MonsterAction Clone(int newDungemonId)
		{
			return new MonsterAction
			{
				DungemonId = newDungemonId,
				Name = Name,
				Description = Description
			};
		}
	}
}
