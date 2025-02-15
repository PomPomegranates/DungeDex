﻿using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
	public interface IDungemonService
	{
		Task<List<Dungemon>?> GetDungemon(DungemonFilterDto filterDto);
		Task<(Dungemon?, string)> GetDungemonById(int id);
		Task<(Dungemon?, string)> AddDungemon(Dungemon monster);
		Task<(Dungemon?, string)> UpdateDungemon(Dungemon monster);
		Task<string> DeleteDungemonById(int id, string jwtUserId);
	}
}