using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
    public interface IUserDungeMonRepository
    {
        List<DungeMon>? GetMonsters();
        (DungeMon?, string) GetSingularMonster(int id);
        (DungeMon, string) PostUserMonster(DungeMon monster);
    }
}