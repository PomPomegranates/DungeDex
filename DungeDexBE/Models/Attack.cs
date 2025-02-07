using DungeDexBE.Enums;

namespace DungeDexBE.Models
{
	public class Attack
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public int AttackBonus { get; set; }
		public Damage DamageType { get; set; }
		public string DamageDice { get; set; } = null!;
	}
}
