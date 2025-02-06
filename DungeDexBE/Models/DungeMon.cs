using DungeDexBE.Interfaces.ModelInterfaces;
//using DungeDexBE.Models.NavigationModels;

namespace DungeDexBE.Models
{
    public class DungeMon : IReturnable
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public virtual User? User { get; set; }
		public string BasePokemon { get; set; } = null!;
		public string NickName { get; set; } = string.Empty;
		public float ChallengeRating { get; set; }
		public int ProficiencyBonus { get; set; }
		public int ArmorClass { get; set; }
		public int Strength { get; set; }
		public int Dexterity { get; set; }
		public int Constitution { get; set; }
		public int Intelligence { get; set; }
		public int Wisdom { get; set; }
		public int Charisma { get; set; }
		public int HitPoints { get; set; }
		public virtual List<Spell> Spells { get; set; } = [];
		public virtual List<Action> Actions { get; set; } = [];
		public string ImageLink { get; set; }
		public string Proficiencies { get; set; } = string.Empty;

		#region stretch
		//public Size Size { get; set; }
		//public string Type { get; set; }
		//public Speed Speeds { get; set; }
		//public int ProficiencyBonus { get; set; }
		//public List<Attributes> SavingThrows { get; set; }
		//public string? HitDice { get; set; }

		//public List<string> Proficiences { get; set; }
		//public List<Damage> DamageVulnerabilities { get; set; } = [];
		//public List<Damage> DamageResistances { get;set; } = [];
		//public List<Condition> ConditionImmunities { get; set; } = [];
		//public Dictionary<string, string> SpecialAbilities { get; set; }
		//public List<int> AttackIds { get; set; }
		////Need a table of attacks in our database for this to pull from
		//public EAttributes? SpellcastingAbility { get; set; }
		//public int? SpellSaveDC { get; set; }
		////public List<LegendaryAction>? LegendaryActions { get; set; }
		//public string Description { get; set; }
		#endregion
	}
}
