using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;

namespace DungeDexBE.Services
{
	public class UserDungeMonService : IUserDungeMonService
	{
		private readonly IUserDungeMonRepository _userDungeMonRepository;

		public UserDungeMonService(IUserDungeMonRepository userDungeMonRepository)
		{
			_userDungeMonRepository = userDungeMonRepository;
		}

		public List<DungeMon>? GetMonsters()
		{
			return _userDungeMonRepository.GetMonsters();
		}
		public (DungeMon?, string) GetSingularMonster(int id)
		{
			return _userDungeMonRepository.GetSingularMonster(id);
		}
		public (DungeMon, string) PostUserMonster(DungeMon monster)
		{
			return _userDungeMonRepository.PostUserMonster(monster);
		}

		public (DungeMon?, string) PatchUserMonster(DungeMon dungemon)
		{
			var result = _userDungeMonRepository.GetSingularMonster(dungemon.Id);

			return _userDungeMonRepository.PatchUserMonster(dungemon);
		}
	}
}
