namespace DungeDexBE.Models
{
    public class Spell
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Range { get; set; }
        public string Duration { get; set; }
        public bool Concentration { get; set; }
        public string CastTime { get; set; }
        public Damage DamageType { get; set; }
        public EAttributes DcType { get; set; }
        public float DcSuccess { get; set; }
        public AoEType areaOfEffectType { get; set; }
        public int areaOfEffectSize { get; set; }

    }
}
}
