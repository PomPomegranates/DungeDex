namespace DungeDexBE.Models
{
    public class Attack
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AttackBonus { get; set; }
        public Damage DamageType { get; set; }
        public string DamageDice { get; set; }
    }
}
