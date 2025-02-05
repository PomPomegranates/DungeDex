using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
	public interface IUserDungeMonService
	{
		List<Dungemon>? GetDungemon(DungemonFilterDto filterDto);
		(Dungemon?, string) GetDungemonById(int id);
		(Dungemon?, string) AddDungemon(Dungemon monster);
		(Dungemon?, string) UpdateDungemon(Dungemon monster);
		string DeleteDungemonById(int id);
	}
}