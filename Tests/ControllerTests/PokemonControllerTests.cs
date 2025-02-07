using System.Net;
using AutoFixture;
using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.ControllerTests
{
	internal class PokemonControllerTests
	{
		private Mock<IPokemonService> _mockPokemonService;
		private PokemonController _controller;
		private Fixture _fixture;

		[SetUp]
		public void Setup()
		{
			_mockPokemonService = new Mock<IPokemonService>();
			_controller = new PokemonController(_mockPokemonService.Object);
			_fixture = new Fixture();
		}

		[Test]
		public async Task GetBasePokemon_ValidQuery_ReturnsOkPokemon()
		{
			// Arrange
			var testPokemon = _fixture.Create<Pokemon>();
			var testResult = new Result
			{
				Value = testPokemon
			};

			_mockPokemonService
				.Setup(p => p.GetBasePokemonAsync(testPokemon.Name))
				.ReturnsAsync(testResult);

			// Act
			var result = await _controller.GetBasePokemon(testPokemon.Name);

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(testPokemon);
		}

		[Test]
		public async Task GetBasePokemon_InvalidQuery_ReturnsNotFound()
		{
			// Arrange
			var testInvalidQuery = _fixture.Create<string>();
			var testResult = new Result
			{
				IsSuccess = false,
				StatusCode = HttpStatusCode.NotFound,
				ErrorMessage = $"PokéAPI Error: Could not find pokemon with index '{testInvalidQuery}'"
			};

			_mockPokemonService
				.Setup(p => p.GetBasePokemonAsync(testInvalidQuery))
				.ReturnsAsync(testResult);

			// Act
			var result = await _controller.GetBasePokemon(testInvalidQuery);

			// Assert
			result.Should().BeOfType<ObjectResult>();
			var objectResult = result as ObjectResult;
			objectResult?.StatusCode.Should().Be(404);
			objectResult?.Value.Should().BeEquivalentTo(testResult.ErrorMessage);
		}

		[Test]
		public async Task GetMonsterFromPokemon_InvalidQuery_ReturnsNotFound()
		{
			// Arrange
			var testInvalidQuery = _fixture.Create<string>();
			var testResult = new Result
			{
				IsSuccess = false,
				StatusCode = HttpStatusCode.NotFound,
				ErrorMessage = $"PokéAPI Error: Could not find pokemon with index '{testInvalidQuery}'"
			};

			_mockPokemonService
				.Setup(p => p.GetDungemonFromPokemonAsync(testInvalidQuery))
				.ReturnsAsync(testResult);

			// Act
			var result = await _controller.GetMonsterFromPokemon(testInvalidQuery);

			// Assert
			result.Should().BeOfType<ObjectResult>();
			var objectResult = result as ObjectResult;
			objectResult?.StatusCode.Should().Be(404);
			objectResult?.Value.Should().BeEquivalentTo(testResult.ErrorMessage);
		}
	}
}
