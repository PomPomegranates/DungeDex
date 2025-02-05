namespace DungeDexBE.Models.Dtos
{
	public class DungemonFilterDto(string? basePokemon, int number, int offset)
	{
		public int Number { get; set; } = number;
		public int Offset { get; set; } = offset;
		public string? BasePokemon { get; set; } = basePokemon;
	}
}
