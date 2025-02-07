using AutoFixture;
using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.RepositoryInterfaces;
using DungeDexBE.Interfaces.ServiceInterfaces;
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
	}
}
