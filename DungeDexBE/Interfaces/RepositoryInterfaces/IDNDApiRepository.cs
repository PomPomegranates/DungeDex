namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
    public interface IDNDApiRepository
    {
        Task<Dictionary<string, string>> GetAllSpellsNamesAsync();
    }
}