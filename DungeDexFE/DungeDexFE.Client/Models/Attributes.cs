using System.ComponentModel.DataAnnotations;

namespace DungeDexFE.Client.Models
{
	public class Attributes
	{
		[Range(0,30, ErrorMessage = "Strength must be between 0 and 30")]
		public int Strength { get; set; }
		[Range(0,30, ErrorMessage = "Dexterity must be between 0 and 30")]
		public int Dexterity { get; set; }
		[Range(0,30, ErrorMessage = "Constitution must be between 0 and 30")]
		public int Constitution { get; set; }
		[Range(0,30, ErrorMessage = "Intelligence must be between 0 and 30")]
		public int Intelligence { get; set; }
		[Range(0,30, ErrorMessage = "Wisdom must be between 0 and 30")]
		public int Wisdom { get; set; }
		[Range(0,30, ErrorMessage = "Charisma must be between 0 and 30")]
		public int Charisma { get; set; }
	}
}
