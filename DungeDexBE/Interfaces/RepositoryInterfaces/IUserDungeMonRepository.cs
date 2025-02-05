using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
    public interface IUserDungeMonRepository
    {
        List<DungeMon>? GetMonsters();
        (DungeMon?, string) GetSingularMonster(int id);
        (DungeMon, string) PostUserMonster(DungeMon monster);
        (DungeMon, string) PatchUserMonster(DungeMon monster);
        string DeleteUserMonster(int monsterId);
    }
}