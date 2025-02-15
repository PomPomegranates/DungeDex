﻿using DungeDexBE.Models;

namespace DungeDexBE.Interfaces.ServiceInterfaces
{
	public interface IPokemonService
	{
		Task<Result> GetBasePokemonAsync(string pokemonName);
		Task<Result> GetDungemonFromPokemonAsync(string pokemonName);

	}
}
