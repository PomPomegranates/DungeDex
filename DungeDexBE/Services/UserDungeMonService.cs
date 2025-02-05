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

		public List<DungeMon>? GetDungemon(DungemonFilterDto filterDto)
		{
			return _userDungeMonRepository.GetMonsters(filterDto);
		}
		public (DungeMon?, string) GetDungemonById(int id)
		{
			return _userDungeMonRepository.GetSingularMonster(id);
		}
		public (DungeMon, string) AddDungemon(DungeMon monster)
		{
			return _userDungeMonRepository.PostUserMonster(monster);
		}

		public (DungeMon?, string) UpdateDungemon(DungeMon dungemon)
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
