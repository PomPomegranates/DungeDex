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

		public List<DungeMon>? GetMonsters()
		{
			return _userDungeMonRepository.GetMonsters();
		}
		public ( DungeMon? , string ) GetSingularMonster(int id)
		{
			return _userDungeMonRepository.GetSingularMonster(id);
		}
		public (DungeMon, string) PostUserMonster(DungeMon monster)
		{
			return _userDungeMonRepository.PostUserMonster(monster);
		}

		public (DungeMon?, string) PatchUserMonster(DungeMon dungemon, User user)
		{
			
                var result = _userDungeMonRepository.GetSingularMonster(dungemon.Id);
				if (result.Item2 == "Success")
			{
				if(result.Item1!.UserId == user.Id)
				{
                    return _userDungeMonRepository.PatchUserMonster(dungemon);
				}
				else
				{
					return (null, "Not Authorised - You are not the Dungemon's creator");
				}
			}
			else
			{
				return result;
			}

                    

			
			
		}
	}
}
