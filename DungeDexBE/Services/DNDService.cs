using DungeDexBE.Interfaces.RepositoryInterfaces;

namespace DungeDexBE.Services
{
	public class DNDService
	{
		private readonly IDNDApiRepository _apiRepository;

		public DNDService(IDNDApiRepository apiRepository)
		{
			_apiRepository = apiRepository;
		}

		public async Task<Dictionary<string, string>> GetAllSpellNames()
		{
			return await _apiRepository.GetAllSpellsNamesAsync();
		}
	}
}
