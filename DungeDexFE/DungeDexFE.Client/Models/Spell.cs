using System.Text.Json.Serialization;

namespace DungeDexFE.Client.Models
{
	public class Spell
	{
		public int Id { get; set; }
		public int DungemonId { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		[JsonIgnore(Condition = JsonIgnoreCondition.Always)]
		public Guid? ClientId = Guid.NewGuid();

		#region stretch
		//public string Range { get; set; }
		//public string Duration { get; set; }
		//public string CastTime { get; set; }
		//public Damage DamageType { get; set; }
		//public EAttributes DcType { get; set; }
		//public float DcSuccess { get; set; }
		//public AoEType areaOfEffectType { get; set; }
		//public int areaOfEffectSize { get; set; }
		#endregion

		public Spell Clone(int newDungemonId)
		{
			return new Spell
			{
				DungemonId = newDungemonId,
				Name = Name,
				Description = Description
			};
		}
	}
}