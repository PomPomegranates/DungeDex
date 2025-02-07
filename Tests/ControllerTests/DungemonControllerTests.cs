using AutoFixture;
using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Moq;

namespace Tests.ControllerTests
{
	internal class DungemonControllerTests
	{
		private Mock<IDungemonService> _mockDungemonService;
		private Mock<IJwtService> _mockJwtService;
		private DungemonController _controller;
		private Fixture _fixture;

		[SetUp]
		public void SetUp()
		{
			_mockDungemonService = new Mock<IDungemonService>();
			_mockJwtService = new Mock<IJwtService>();
			_controller = new DungemonController(_mockDungemonService.Object, _mockJwtService.Object);
			_fixture = new Fixture();
			_fixture.Behaviors
				.OfType<ThrowingRecursionBehavior>()
				.ToList()
				.ForEach(b => _fixture.Behaviors.Remove(b));
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			_fixture.Customize<Dungemon>(d => d
				.With(d => d.User, _fixture.Create<User>())
				.With(d => d.Spells, _fixture.CreateMany<Spell>(2).ToList())
				.With(d => d.Actions, _fixture.CreateMany<DungeDexBE.Models.Action>(4).ToList()));
				
		}

		[Test]
		public async Task GetAllDungemon_NoDungemon_ReturnsNotFound()
		{
			// Arrange
			_mockDungemonService
				.Setup(d => d.GetDungemon(It.IsAny<DungemonFilterDto>()))
				.ReturnsAsync(new List<Dungemon>());

			// Act
			var result = await _controller.GetAllDungemon(10, 0, null);

			// Assert
			result.Should().BeOfType<NotFoundResult>();
		}

		[Test]
		public async Task GetAllDungemon_DungemonExist_ReturnsOkExpectedDungemon()
		{
			// Arrange
			var expectedDungemon = _fixture.CreateMany<Dungemon>(10).ToList();
			_mockDungemonService
				.Setup(d => d.GetDungemon(It.IsAny<DungemonFilterDto>()))
				.ReturnsAsync(expectedDungemon);

			// Act
			var result = await _controller.GetAllDungemon(10, 0, null);

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expectedDungemon);
		}
	}
}
