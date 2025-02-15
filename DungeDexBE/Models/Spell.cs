﻿using DungeDexBE.Interfaces.ModelInterfaces;

namespace DungeDexBE.Models
{
	public class Spell : IReturnable
	{
		public int Id { get; set; }
		public int DungemonId { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		#region stretch
		//public string Range { get; set; }
		//public string Duration { get; set; }
		//public string CastTime { get; set; }
		//public Damage DamageType { get; set; }
		//public EAttributes DcType { get; set; }
		//public float DcSuccess { get; set; }
		//public AoEType areaOfEffectType { get; set; }
		//public int areaOfEffectSize { get; set; }
		#endregion
	}
}