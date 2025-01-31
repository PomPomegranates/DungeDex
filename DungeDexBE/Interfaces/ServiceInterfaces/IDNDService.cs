using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
    public interface IDNDService
    {
        Task<Dictionary<string, string>?> GetAllSpellNamesAsync();
        Task<Result> GetSpellByNameOrIndex(string nameOrIndex);

	}
}