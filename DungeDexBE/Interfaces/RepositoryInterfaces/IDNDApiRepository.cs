using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
    public interface IDNDApiRepository
    {
        Task<Dictionary<string, string>?> GetAllSpellsNamesAsync();
        Task<Result> GetSpellByNameOrIndex(string nameOrIndex);
        Task<Result> GetRandomSpell();

	}
}