using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Services
{
	public class DungemonService : IDungemonService
	{
		private readonly IDungemonRepository _userDungemonRepository;

		public DungemonService(IDungemonRepository userDungemonRepository)
		{
			_userDungemonRepository = userDungemonRepository;
		}

		public async Task<List<Dungemon>?> GetDungemon(DungemonFilterDto filterDto)
		{
			return await _userDungemonRepository.GetDungemon(filterDto);
		}
		public async Task<(Dungemon?, string)> GetDungemonById(int id)
		{
			return await _userDungemonRepository.GetDungemonById(id);
		}
		public async Task<(Dungemon?, string)> AddDungemon(Dungemon monster)
		{
			return await _userDungemonRepository.AddDungemon(monster);
		}

		public async Task<(Dungemon?, string)> UpdateDungemon(Dungemon dungemon)
		{
			return await _userDungemonRepository.UpdateDungemon(dungemon);
		}

		public async Task<string> DeleteDungemonById(int dungemonId, string jwtUserId)
		{
			return await _userDungemonRepository.DeleteDungemonById(dungemonId, jwtUserId);
		}
	}
}
