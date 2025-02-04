using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Services
{
    public class UserDungeMonService : IUserDungeMonService
	{
		private readonly IUserDungeMonRepository _userDungeMonRepository;

		public UserDungeMonService(IUserDungeMonRepository userDungeMonRepository)
		{
			_userDungeMonRepository = userDungeMonRepository;
		}

		public List<Monster>? GetMonsters()
		{
			return _userDungeMonRepository.GetMonsters();
		}
		public ( Monster? , string ) GetSingularMonster(int id)
		{
			return _userDungeMonRepository.GetSingularMonster(id);
		}
		public (Monster, string) PostUserMonster(Monster monster)
		{
			return _userDungeMonRepository.PostUserMonster(monster);
		}
	}
}
