using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
    public interface IUserPokemonsterService
    {
        List<Monster>? GetMonsters();
    }
}