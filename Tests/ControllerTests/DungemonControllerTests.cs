using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.ControllerTests
{
	internal class DungemonControllerTests
	{
		private Mock<IDungemonService> _mockDungemonService;
		private Mock<IJwtService> _mockJwtService;
		private DungemonController _controller;

		[SetUp]
		public void SetUp()
		{
			_mockDungemonService = new Mock<IDungemonService>();
			_mockJwtService = new Mock<IJwtService>();
			_controller = new DungemonController(_mockDungemonService.Object, _mockJwtService.Object);
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
	}
}
