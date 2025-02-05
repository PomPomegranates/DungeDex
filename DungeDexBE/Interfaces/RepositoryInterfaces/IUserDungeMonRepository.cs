using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
	public interface IUserDungeMonRepository
	{
		List<DungeMon>? GetMonsters(DungemonFilterDto filterDto);
		(DungeMon?, string) GetSingularMonster(int id);
		(DungeMon, string) PostUserMonster(DungeMon monster);
		(DungeMon, string) PatchUserMonster(DungeMon monster);
		string DeleteUserMonster(int monsterId);
	}
}