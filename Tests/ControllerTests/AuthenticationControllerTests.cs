using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.ControllerTests
{
	internal class AuthenticationControllerTests
	{
		private Mock<IJwtService> _mockJwtService;
		private Mock<UserManager<User>> _mockUserManager;
		private Mock<IUserStore<User>> _mockUserStore;
		private AuthenticationController _controller;

		[SetUp]
		public void SetUp()
		{
			_mockJwtService = new Mock<IJwtService>();
			_mockUserStore = new Mock<IUserStore<User>>();
			_mockUserManager = new Mock<UserManager<User>>(_mockUserStore.Object, null, null, null, null, null, null, null, null);
			_controller = new AuthenticationController(_mockUserManager.Object, _mockJwtService.Object);
		}

		[Test]
		public async Task Login_ValidDetails_ReturnsOkAndJwt()
		{
			// Arrange
			var testLoginModel = new LoginModel()
			{
				UserName = "CorrectTestUserName",
				Password = "CorrectTestPassword"
			};
			var testUser = new User()
			{
				UserName = "CorrectTestUserName"
			};
			var token = "a-valid-and-very-very-secure-json-web-token";
			var expected = new
			{
				token
			};
			_mockUserManager.Setup(u => u.FindByNameAsync(testLoginModel.UserName)).ReturnsAsync(testUser);
			_mockUserManager.Setup(u => u.CheckPasswordAsync(testUser, testLoginModel.Password)).ReturnsAsync(true);
			_mockJwtService.Setup(j => j.GenerateJwtToken(testUser)).Returns(token);

			// Act
			var result = await _controller.Login(testLoginModel);

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expected);
		}
	}
}
