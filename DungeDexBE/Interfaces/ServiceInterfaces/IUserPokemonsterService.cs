using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
    public interface IUserPokemonsterService
    {
        List<Monster>? GetMonsters();
        (Monster?, string) GetSingularMonster(int id);
        (Monster, string) PostUserMonster(Monster monster);
    }
}