using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
	public interface IUserDungeMonRepository
	{
		List<Dungemon>? GetMonsters(DungemonFilterDto filterDto);
		(Dungemon?, string) GetSingularMonster(int id);
		(Dungemon, string) PostUserMonster(Dungemon monster);
		(Dungemon, string) PatchUserMonster(Dungemon monster);
		string DeleteUserMonster(int monsterId);
	}
}