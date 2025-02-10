using AutoFixture;
using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.ControllerTests
{
	internal class SpellsControllerTests
	{
		private Mock<IDNDService> _mockDndService;
		private SpellsController _controller;
		private Fixture _fixture;

		[SetUp]
		public void SetUp()
		{
			_mockDndService = new Mock<IDNDService>();
			_controller = new SpellsController(_mockDndService.Object);
			_fixture = new Fixture();
		}

		[Test]
		public async Task GetAllSpellNamesAsync_CannotContactAPI_ReturnsInternalServerError()
		{
			// Arrange
			_mockDndService
				.Setup(d => d.GetAllSpellNamesAsync())
				.ReturnsAsync(() => null);

			var expectedErrorMessage = "There was an issue contacting the API.";

			// Act
			var result = await _controller.GetAllSpellNamesAsync();

			// Assert
			result.Should().BeOfType<ObjectResult>();
			var objectResult = result as ObjectResult;
			objectResult?.StatusCode.Should().Be(500);
			objectResult?.Value.Should().Be(expectedErrorMessage);
		}

		[Test]
		public async Task GetAllSpellNamesAsync_CannotDeserialize_ReturnsInternalServerError()
		{
			// Arrange
			_mockDndService
				.Setup(d => d.GetAllSpellNamesAsync())
				.ReturnsAsync(() => []);

			var expectedErrorMessage = "There was an issue converting from JSON to SpellDTO.";

			// Act
			var result = await _controller.GetAllSpellNamesAsync();

			// Assert
			result.Should().BeOfType<ObjectResult>();
			var objectResult = result as ObjectResult;
			objectResult?.StatusCode.Should().Be(500);
			objectResult?.Value.Should().Be(expectedErrorMessage);
		}

		[Test]
		public async Task GetAllSpellNamesAsync_NoExceptions_ReturnsOkExpectedSpellDtos()
		{
			// Arrange
			var expectedSpells = _fixture.CreateMany<KeyValuePair<string, string>>(50).ToDictionary();
			_mockDndService
				.Setup(d => d.GetAllSpellNamesAsync())
				.ReturnsAsync(expectedSpells);

			// Act
			var result = await _controller.GetAllSpellNamesAsync();

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expectedSpells);
		}

		[Test]
		public async Task GetSpellByNameOrIndex_InvalidQuery_ReturnsNotFound()
		{
			// Arrange
			var testInvalidQuery = _fixture.Create<string>();
			var expectedResult = new Result
			{
				IsSuccess = false,
				StatusCode = System.Net.HttpStatusCode.NotFound,
				ErrorMessage = $"No spell with index '{testInvalidQuery}' exists."
			};

			_mockDndService
				.Setup(d => d.GetSpellByNameOrIndex(testInvalidQuery))
				.ReturnsAsync(expectedResult);

			// Act
			var result = await _controller.GetSpellByNameOrIndex(testInvalidQuery);

			// Assert
			result.Should().BeOfType<ObjectResult>();
			var objectResult = result as ObjectResult;
			objectResult?.StatusCode.Should().Be(404);
			objectResult?.Value.Should().Be(expectedResult.ErrorMessage);
		}

		[Test]
		public async Task GetSpellByNameOrIndex_ValidQuery_ReturnsOkExpectedSpell()
		{
			// Arrange
			var testQuery = _fixture.Create<string>();
			var testSpell = _fixture.Create<Spell>();
			var expectedResult = new Result
			{
				Value = testSpell
			};

			_mockDndService
				.Setup(d => d.GetSpellByNameOrIndex(testQuery))
				.ReturnsAsync(expectedResult);

			// Act
			var result = await _controller.GetSpellByNameOrIndex(testQuery);

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().Be(testSpell);
		}
	}
}
