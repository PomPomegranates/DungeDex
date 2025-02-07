using AutoFixture;
using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Services;
using FluentAssertions;
using k8s.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.ControllerTests
{
	internal class UsersControllerTests
	{
		private Mock<IUserService> _mockUserService;
		private UserController  _controller;
		private Fixture _fixture;

		[SetUp]
		public void SetUp()
		{
			_mockUserService = new Mock<IUserService>();
			_controller = new UserController(_mockUserService.Object);
			_fixture = new Fixture();
			_fixture.Customize<User>(u => u
				.With(u => u.Dungemons, () => []));
		}

		[Test]
		public void GetUsers_NoUsers_ReturnsNotFound()
		{
			// Arrange
			_mockUserService
				.Setup(u => u.GetUsers())
				.Returns(() => []);

			// Act
			var result = _controller.GetUsers();

			// Assert
			result.Should().BeOfType<NotFoundResult>();
		}

		[Test]
		public void GetUsers_Users_ReturnsOkExpectedUsers()
		{
			// Arrange
			var testUsers = _fixture.CreateMany<User>(10).ToList();
			_mockUserService
				.Setup(u => u.GetUsers())
				.Returns(testUsers);

			// Act
			var result = _controller.GetUsers();

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(testUsers);
		}
	}
}
