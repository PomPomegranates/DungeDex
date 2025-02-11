namespace DungeDexBE.Models.Dtos
{
	public class UserDto
	{
		public string Id { get; set; } = null!;
		public string UserName { get; set; } = null!;
		public ICollection<Dungemon> Dungemon { get; set; } = [];
	}

	public static class UserExtensions
	{
		public static UserDto ToDto(this User user)
		{
			return new UserDto
			{
				Id = user.Id,
				UserName = user.UserName ?? string.Empty,
				Dungemon = user.Dungemon
			};
		}
	}
}
