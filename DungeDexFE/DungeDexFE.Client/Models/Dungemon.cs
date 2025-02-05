using System.ComponentModel.DataAnnotations;
using DungeDexFE.Client.Enums;
namespace DungeDexFE.Client.Models
{
	public class Dungemon
	{
		public int Id { get; set; }
		public string BasePokemon { get; set; } = null!;
		public string NickName { get; set; } = null!;
		public int UserId { get; set; }
		[Range(0f, 100f, ErrorMessage = "Challenge Rating must be between 0 and 100.")]
		public float ChallengeRating { get; set; }
		public int ArmorClass { get; set; }
		[Range(0, 30, ErrorMessage = "Strength must be between 0 and 30")]
		public int Strength { get; set; }
		[Range(0, 30, ErrorMessage = "Dexterity must be between 0 and 30")]
		public int Dexterity { get; set; }
		[Range(0, 30, ErrorMessage = "Constitution must be between 0 and 30")]
		public int Constitution { get; set; }
		[Range(0, 30, ErrorMessage = "Intelligence must be between 0 and 30")]
		public int Intelligence { get; set; }
		[Range(0, 30, ErrorMessage = "Wisdom must be between 0 and 30")]
		public int Wisdom { get; set; }
		[Range(0, 30, ErrorMessage = "Charisma must be between 0 and 30")]
		public int Charisma { get; set; }
		public int HitPoints { get; set; }
		public string ImageLink { get; set; } = null!;
		public virtual List<Spell> Spells { get; set; } = null!;

		#region stretch

		public Size Size { get; set; }
		public string Type { get; set; }
		public MoveSpeed Speeds { get; set; }
		public int ProficiencyBonus { get; set; }
		public List<EAttributes> SavingThrows { get; set; }
		public string? HitDice { get; set; }

		public List<string> Proficiences { get; set; }
		public List<Damage> DamageVulnerabilities { get; set; } = [];
		public List<Damage> DamageResistances { get; set; } = [];
		public List<Condition> ConditionImmunities { get; set; } = [];
		public Dictionary<string, string> SpecialAbilities { get; set; }
		public List<int> AttackIds { get; set; }
		//Need a table of attacks in our database for this to pull from
		public EAttributes? SpellcastingAbility { get; set; }
		public int? SpellSaveDC { get; set; }
		//public List<LegendaryAction>? LegendaryActions { get; set; }
		public string Description { get; set; }

		#endregion
	}
}
