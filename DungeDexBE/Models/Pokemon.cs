using DungeDexBE.Interfaces.ModelInterfaces;

namespace DungeDexBE.Models
{
	public class Pokemon : IReturnable
	{
		public string Name { get; set; } = null!;
		public int HP { get; set; }
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int SpecialAttack { get; set; }
		public int SpecialDefense { get; set; }
		public int Speed { get; set; }
		public string ImageLink { get; set; } = null!;
		public string SpriteLink { get; set; } = null!;
		public string Type1 { get; set; } = null!;
        public string? Type2 { get; set; } = null!;
        public string Shape {  get; set; } = null!;
        public bool IsLegendaryOrMythical {  get; set; }
		public string Cry { get; set; } = "";
		public string Description { get; set; } = "";


        public override string ToString() =>
			$"Name:\t{Name}\nHP:\t{HP}Attack:\t{Attack}\nDefense:\t{Defense}\nSpecialAttack:\t{SpecialAttack}\nSpecialDefense:\t{SpecialDefense}\nSpeed:\t{Speed}";
	}
}
