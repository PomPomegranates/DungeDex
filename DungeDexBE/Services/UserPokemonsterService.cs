﻿using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using Microsoft.EntityFrameworkCore;

namespace DungeDexBE.Services
{
    public class UserPokemonsterService : IUserPokemonsterService
	{
		private readonly IUserPokemonsterRepository _userPokemonsterRepository;

		public UserPokemonsterService(IUserPokemonsterRepository userPokemonsterRepository)
		{
			_userPokemonsterRepository = userPokemonsterRepository;
		}

		public List<Monster>? GetMonsters()
		{
			return _userPokemonsterRepository.GetMonsters();
		}
		public ( Monster? , string ) GetSingularMonster(int id)
		{
			return _userPokemonsterRepository.GetSingularMonster(id);
		}
	}
}
