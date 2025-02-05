using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Services
{
	public class UserDungeMonService : IUserDungeMonService
	{
		private readonly IUserDungeMonRepository _userDungeMonRepository;

		public UserDungeMonService(IUserDungeMonRepository userDungeMonRepository)
		{
			_userDungeMonRepository = userDungeMonRepository;
		}

		public List<Dungemon>? GetDungemon(DungemonFilterDto filterDto)
		{
			return _userDungeMonRepository.GetMonsters(filterDto);
		}
		public (Dungemon?, string) GetDungemonById(int id)
		{
			return _userDungeMonRepository.GetSingularMonster(id);
		}
		public (Dungemon, string) AddDungemon(Dungemon monster)
		{
			return _userDungeMonRepository.PostUserMonster(monster);
		}

		public (Dungemon?, string) UpdateDungemon(Dungemon dungemon)
		{
			var result = _userDungeMonRepository.GetSingularMonster(dungemon.Id);

			return _userDungeMonRepository.PatchUserMonster(dungemon);
		}

		public string DeleteDungemonById(int dungemonId)
		{
			return _userDungeMonRepository.DeleteUserMonster(dungemonId);
		}
	}
}
