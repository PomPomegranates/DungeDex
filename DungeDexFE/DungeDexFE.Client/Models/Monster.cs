//namespace DungeDexFE.Client.Models
//{
//	public class Monster
//    {
//		public int Id { get; set; }
//        public string Name { get; set; } = null!;
//		public int ChallengeRating { get; set; }
//		public int ArmorClass { get; set; }
//        public Attributes Attributes { get; set; } = null!;
//        public int HitPoints { get; set; }
//        public virtual List<Spell> Spells { get; set; } = null!;

//		#region stretch
//		public Size Size { get; set; }
//		public string Type { get; set; }
//		public Speed Speeds { get; set; }
//		public int ProficiencyBonus { get; set; }
//		public List<Attributes> SavingThrows { get; set; }
//		public string? HitDice { get; set; }

//		public List<string> Proficiences { get; set; }
//		public List<Damage> DamageVulnerabilities { get; set; } = [];
//		public List<Damage> DamageResistances { get; set; } = [];
//		public List<Condition> ConditionImmunities { get; set; } = [];
//		public Dictionary<string, string> SpecialAbilities { get; set; }
//		public List<int> AttackIds { get; set; }
//		//Need a table of attacks in our database for this to pull from
//		public EAttributes? SpellcastingAbility { get; set; }
//		public int? SpellSaveDC { get; set; }
//		//public List<LegendaryAction>? LegendaryActions { get; set; }
//		public string Description { get; set; }
//		#endregion
//	}
//}
