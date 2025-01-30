using System.Net;
using DungeDexBE.Interfaces.ModelInterfaces;

namespace DungeDexBE.Models
{
	public class Result
	{
		public bool IsSuccess { get; set; } = true;
		public HttpStatusCode? StatusCode { get; set; }
		public IReturnable? Value { get; set; }
		public string? ErrorMessage { get; set; }

		internal object ToMonster()
		{
			throw new NotImplementedException();
		}
	}
}
