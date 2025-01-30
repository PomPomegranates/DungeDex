using DungeDexBE.Enums;

namespace DungeDexBE.Models
{
    public class MoveSpeed
    {
        public int MonsterId { get; set; }
        public MoveType Type { get; set; }
        public int Speed { get; set; }
    }
}
