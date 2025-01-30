namespace DungeDexFE.Client.Models
{
	public class Spell
    {
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

		#region stretch
		public string Range { get; set; }
		public string Duration { get; set; }
		public string CastTime { get; set; }
		public Damage DamageType { get; set; }
		public EAttributes DcType { get; set; }
		public float DcSuccess { get; set; }
		public AoEType areaOfEffectType { get; set; }
		public int areaOfEffectSize { get; set; }
		#endregion
	}
}