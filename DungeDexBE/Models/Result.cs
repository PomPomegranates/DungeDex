using DungeDexBE.Enums;

namespace DungeDexBE.Models
{
	public class Result<T> where T : class
	{
		public Outcome Outcome { get; set; } = Outcome.Success;
		public T? Value { get; set; }
		public string? ErrorMessage { get; set; }
	}
}
