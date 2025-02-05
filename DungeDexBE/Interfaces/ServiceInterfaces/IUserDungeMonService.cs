using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
	public interface IUserDungeMonService
    {
        List<DungeMon>? GetMonsters();
        (DungeMon?, string) GetSingularMonster(int id);
        public (DungeMon?, string) PostUserMonster(DungeMon monster);

        public (DungeMon?, string) PatchUserMonster(DungeMon monster);
    }
}