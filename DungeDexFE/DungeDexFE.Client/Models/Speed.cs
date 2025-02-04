using DungeDexFE.Client.Enums;

namespace DungeDexFE.Client.Models
{
	public class MoveSpeed
	{
		public int MonsterId { get; set; }
		public MoveType Type { get; set; }
		public int Speed { get; set; }
	}
}
