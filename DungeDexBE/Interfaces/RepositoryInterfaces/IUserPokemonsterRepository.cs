using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
    public interface IUserPokemonsterRepository
    {
        List<Monster>? GetMonsters();
        (Monster?, string) GetSingularMonster(int id);
        (Monster, string) PostUserMonster(Monster monster);
    }
}