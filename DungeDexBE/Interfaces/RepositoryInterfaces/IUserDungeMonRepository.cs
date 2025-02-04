using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
    public interface IUserDungeMonRepository
    {
        List<Monster>? GetMonsters();
        (Monster?, string) GetSingularMonster(int id);
        (Monster, string) PostUserMonster(Monster monster);
    }
}