using DungeDexBE.Enums;

namespace DungeDexBE.Models.Dtos
{
	public class ActionDTO
	{
		public string Name { get; set; }
		public int? Range { get; set; }
		public ActionType? ActionType { get; set; }
		public int? AttackBonus { get; set; }
		public Damage? DamageType { get; set; }
		public string? DamageDice { get; set; }
		public override string ToString()
		{
			return $"{ActionType.ToString()}: +{AttackBonus} to hit, reach {Range} ft. Hit: {DamageDice} {DamageType.ToString()} damage.";
		}
	}
}
