namespace DungeDexBE.Interfaces.ServiceInterfaces
{
    public interface IDNDService
    {
        Task<Dictionary<string, string>> GetAllSpellNames();
    }
}