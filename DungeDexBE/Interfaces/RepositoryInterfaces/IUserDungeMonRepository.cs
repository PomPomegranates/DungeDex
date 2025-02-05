using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Interfaces.RepositoryInterfaces
{
	public interface IUserDungeMonRepository
	{
		List<Dungemon>? GetDungemon(DungemonFilterDto filterDto);
		(Dungemon?, string) GetDungemonById(int id);
		(Dungemon, string) AddDungemon(Dungemon monster);
		(Dungemon, string) UpdateDungemon(Dungemon monster);
		string DeleteDungemonById(int monsterId);
	}
}