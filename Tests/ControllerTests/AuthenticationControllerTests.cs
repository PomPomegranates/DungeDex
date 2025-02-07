using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
				UserName = testLoginModel.UserName
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

		[Test]
		public async Task Login_IncorrectPassword_ReturnsUnauthorized()
		{
			// Arrange
			var testLoginModel = new LoginModel()
			{
				UserName = "CorrectTestUserName",
				Password = "IncorrectTestPassword"
			};
			var testUser = new User()
			{
				UserName = testLoginModel.UserName
			};
			_mockUserManager.Setup(u => u.FindByNameAsync(testLoginModel.UserName)).ReturnsAsync(testUser);
			_mockUserManager.Setup(u => u.CheckPasswordAsync(testUser, testLoginModel.Password)).ReturnsAsync(false);

			// Act
			var result = await _controller.Login(testLoginModel);

			// Assert
			result.Should().BeOfType<UnauthorizedResult>();
		}

		[Test]
		public async Task Login_IncorrectUsername_ReturnsUnauthorized()
		{
			// Arrange
			var testLoginModel = new LoginModel()
			{
				UserName = "IncorrectTestUserName",
				Password = "CorrectTestPassword"
			};
			_mockUserManager.Setup(u => u.FindByNameAsync(testLoginModel.UserName)).ReturnsAsync(() => null);

			// Act
			var result = await _controller.Login(testLoginModel);

			// Assert
			result.Should().BeOfType<UnauthorizedResult>();
		}

		[Test]
		public async Task Register_ValidDetails_ReturnsOKSuccess()
		{
			// Arrange
			var testLoginModel = new LoginModel()
			{
				UserName = "ValidTestUserName",
				Password = "ValidTestPassword"
			};
			_mockUserManager
				.Setup(u => u.CreateAsync(It.IsAny<User>(), testLoginModel.Password))
				.ReturnsAsync(IdentityResult.Success);
			var expected = new
			{
				Message = "Successfully registered!"
			};

			// Act
			var result = await _controller.Register(testLoginModel);

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expected);
		}

		[Test]
		public async Task Register_InvalidDetails_ReturnsBadRequestWithErrors()
		{
			// Arrange
			var testLoginModel = new LoginModel()
			{
				UserName = "ExistingUsername",
				Password = "bad pw"
			};
			var expectedIdentityErrors = new IdentityError[]
			{
				new() { Code = "Password must be at least 8 characters long." },
				new() { Code = "Password must contain at least 1 number." },
				new() { Code = "Password must not contain spaces." },
				new() { Code = "Password must contain at least 1 uppercase letter." },
				new() { Code = "Username must be unique." },
			};
			_mockUserManager
				.Setup(u => u.CreateAsync(It.IsAny<User>(), testLoginModel.Password))
				.ReturnsAsync(IdentityResult.Failed(expectedIdentityErrors));

			// Act
			var result = await _controller.Register(testLoginModel);

			// Assert
			result.Should().BeOfType<BadRequestObjectResult>();
			var objectResult = result as BadRequestObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expectedIdentityErrors);
		}

		[Test]
		public void GetCurrentUser_ValidToken_ReturnsUserDetails()
		{
			// Arrange
			var expectedUserId = "TestUserId";
			var expectedUserName = "TestUserName";

			_mockJwtService.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
						   .Returns(expectedUserId);
			_mockJwtService.Setup(j => j.ValidateUserNameFromJwt(It.IsAny<HttpRequest>()))
						   .Returns(expectedUserName);
			var httpContext = new DefaultHttpContext();
			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = httpContext
			};
			var expected = new { UserId = expectedUserId, UserName = expectedUserName };

			// Act
			var result = _controller.GetCurrentUser();

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expected);
		}

		[Test]
		public void GetCurrentUser_InvalidToken_ReturnsUnauthorized()
		{
			// Arrange
			_mockJwtService.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
						   .Returns(() => null);
			_mockJwtService.Setup(j => j.ValidateUserNameFromJwt(It.IsAny<HttpRequest>()))
						   .Returns(() => null);
			var httpContext = new DefaultHttpContext();
			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = httpContext
			};
			var expected = "Session token is missing or invalid.";

			// Act
			var result = _controller.GetCurrentUser();

			// Assert
			result.Should().BeOfType<UnauthorizedObjectResult>();
			var objectResult = result as UnauthorizedObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expected);
		}

	}
}
