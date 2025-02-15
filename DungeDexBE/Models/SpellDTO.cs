﻿using System.Text.Json.Serialization;

namespace DungeDexBE.Models
{
	public class SpellDTO
	{
		[JsonPropertyName("index")]
		public string Index { get; set; } = null!;
		[JsonPropertyName("name")]
		public string Name { get; set; } = null!;
		[JsonPropertyName("level")]
		public int Level { get; set; }
	}
}
