using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;

namespace DungeDexBE.Services
{
    public class DNDService : IDNDService
	{
		private readonly IDNDApiRepository _apiRepository;

		public DNDService(IDNDApiRepository apiRepository)
		{
			_apiRepository = apiRepository;
		}

		public async Task<Dictionary<string, string>?> GetAllSpellNamesAsync()
		{
			return await _apiRepository.GetAllSpellsNamesAsync();
		}

		public async Task<Result> GetSpellByNameOrIndex(string nameOrIndex)
		{
			return await _apiRepository.GetSpellByNameOrIndex(nameOrIndex);
		}
	}
}
