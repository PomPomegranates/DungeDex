using DungeDexBE.Interfaces.ModelInterfaces;

namespace DungeDexBE.Models
{
	public class Pokemon : IReturnable
	{
		public string Name { get; set; }
		public int HP { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int SpecialAttack { get; set; }
		public int SpecialDefense { get; set; }
		public int Speed { get; set; }
		public string ImageLink { get; set; }
		#region stretch
		//public string Type1 { get; set; }
		//public string? Type2 { get; set; }
		#endregion


		public override string ToString() =>
			$"Name:\t{Name}\nHP:\t{HP}Attack:\t{Attack}\nDefense:\t{Defense}\nSpecialAttack:\t{SpecialAttack}\nSpecialDefense:\t{SpecialDefense}\nSpeed:\t{Speed}";
	}
}
