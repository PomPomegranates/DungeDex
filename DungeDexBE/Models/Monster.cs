using System.Net;

namespace DungeDexBE.Models
{
    public class Monster
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Size Size { get; set; }
        public string Type { get; set; }
        public Speed Speeds { get; set; }
        public int ProficiencyBonus { get; set; }
        public List<Attributes> SavingThrows { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string? HitDice { get; set; }
        public Attributes Attributes { get; set; }  

        public List<string> Proficiences { get; set; }
        public List<Damage> DamageVulnerabilities { get; set; } = new();
        public List<Damage> DamageResistances { get;set; } = new();
        public List<Condition> ConditionImmunities { get; set; } = new();

        public int ChallengeRating { get; set; }
        public Dictionary<string, string> SpecialAbilities { get; set; }
        public List<int> AttackIds { get; set; }
        //Need a table of attacks in our database for this to pull from
        public EAttributes? SpellcastingAbility { get; set; }
        public List<Spell> Spells { get; set; } = new List<Spell>();
        public int? SpellSaveDC { get; set; }
        //public List<LegendaryAction>? LegendaryActions { get; set; }
        public string Description { get; set; }
    }
}
