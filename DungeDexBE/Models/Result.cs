using System.Net;

namespace DungeDexBE.Models
{
	public class Result<T> where T : class
	{
		public bool IsSuccess { get; set; } = true;
		public HttpStatusCode? StatusCode { get; set; }
		public T? Value { get; set; }
		public string? ErrorMessage { get; set; }
	}
}
