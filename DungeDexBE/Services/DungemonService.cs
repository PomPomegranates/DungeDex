using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Services
{
	public class DungemonService : IDungemonService
	{
		private readonly IUserDungemonRepository _userDungeMonRepository;

		public DungemonService(IUserDungemonRepository userDungeMonRepository)
		{
			_userDungeMonRepository = userDungeMonRepository;
		}

		public async Task<List<Dungemon>?> GetDungemon(DungemonFilterDto filterDto)
		{
			return await _userDungeMonRepository.GetDungemon(filterDto);
		}
		public async Task<(Dungemon?, string)> GetDungemonById(int id)
		{
			return await _userDungeMonRepository.GetDungemonById(id);
		}
		public async Task<(Dungemon?, string)> AddDungemon(Dungemon monster)
		{
			return await _userDungeMonRepository.AddDungemon(monster);
		}

		public async Task<(Dungemon?, string)> UpdateDungemon(Dungemon dungemon)
		{
			return await _userDungeMonRepository.UpdateDungemon(dungemon);
		}

		public async Task<string> DeleteDungemonById(int dungemonId, string jwtUserId)
		{
			return await _userDungeMonRepository.DeleteDungemonById(dungemonId, jwtUserId);
		}
	}
}
