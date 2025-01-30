namespace DungeDexBE.Models
{
	public class Pokemon
	{
		public string Name { get; set; }
		public int HP {  get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int SpecialAttack { get; set; }
		public int SpecialDefense { get; set; }
		public int Speed { get; set; }

		#region stretch
		//public string Type1 { get; set; }
		//public string? Type2 { get; set; }
		#endregion

	}
}
