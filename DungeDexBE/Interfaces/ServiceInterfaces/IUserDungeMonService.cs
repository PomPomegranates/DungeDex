using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
	public interface IUserDungeMonService
	{
		List<DungeMon>? GetDungemon(DungemonFilterDto filterDto);
		(DungeMon?, string) GetDungemonById(int id);
		(DungeMon?, string) AddDungemon(DungeMon monster);
		(DungeMon?, string) UpdateDungemon(DungeMon monster);
		string DeleteDungemonById(int id);
	}
}