using System.ComponentModel.DataAnnotations.Schema;

namespace DungeDexBE.Models
{
	public class MonsterSpell
	{
		public int Id { get; set; }
		[ForeignKey("Monster")]
		public int MonsterId { get; set; }
		[ForeignKey("Spell")]
		public int SpellId { get; set; }
		public virtual Monster Monster { get; set; }
		public virtual Spell Spell { get; set; }
	}
}
