using AutoFixture;
using DungeDexBE.Controllers;
using DungeDexBE.Interfaces.ServiceInterfaces;
using DungeDexBE.Models;
using DungeDexBE.Models.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
				.With(d => d.Actions, _fixture.CreateMany<MonsterAction>(4).ToList()));
				
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

		[Test]
		public async Task GetDungemonById_NoDungemon_ReturnsNotFound()
		{
			// Arrange
			var testId = _fixture.Create<int>();
			var expectedErrorMessage = $"No Dungémon with Id '{testId}' exists";
			_mockDungemonService
				.Setup(d => d.GetDungemonById(testId))
				.ReturnsAsync((null, expectedErrorMessage));

			// Act
			var result = await _controller.GetDungemonById(testId);

			// Assert
			result.Should().BeOfType<NotFoundObjectResult>();
			var objectResult = result as NotFoundObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expectedErrorMessage);
		}

		[Test]
		public async Task GetDungemonById_DungemonExists_ReturnsOkExpectedDungemon()
		{
			// Arrange
			var testId = _fixture.Create<int>();
			var expectedDungemon = _fixture.Create<Dungemon>();
			_mockDungemonService
				.Setup(d => d.GetDungemonById(It.IsAny<int>()))
				.ReturnsAsync((expectedDungemon, "Success"));

			// Act
			var result = await _controller.GetDungemonById(testId);

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().BeEquivalentTo(expectedDungemon);
		}

		[Test]
		public async Task PostDungemon_UserIsAuthorized_ValidDungemon_ReturnsCreatedAtAction()
		{
			// Arrange
			var testDungemon = _fixture.Create<Dungemon>();
			var testNewId = _fixture.Create<int>();
			var testUserId = _fixture.Create<string>();

			_mockJwtService
				.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
				.Returns(testUserId);

			_mockDungemonService
				.Setup(d => d.AddDungemon(It.IsAny<Dungemon>()))
				.ReturnsAsync((Dungemon d) =>
				{
					d.Id = testNewId;
					return (d, "Success");
				});

			var expectedDungemon = testDungemon;
			expectedDungemon.Id = testNewId;
			expectedDungemon.UserId = testUserId;

			// Act
			var result = await _controller.PostDungemon(testDungemon);

			// Assert
			result.Should().BeOfType<CreatedAtActionResult>();
			var objectResult = result as CreatedAtActionResult;
			objectResult?.ActionName.Should().Be(nameof(_controller.GetDungemonById));
			objectResult?.RouteValues.Should().ContainValue(testNewId);
		}

		[Test]
		public async Task PostDungemon_UserIsNotSignedIn_ReturnsUnauthorized()
		{
			// Arrange
			var testDungemon = _fixture.Create<Dungemon>();
			var testNewId = _fixture.Create<int>();
			
			_mockJwtService
				.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
				.Returns(() => null);

			var expectedErrorMessage = "You must be signed-in to publish Dungémon.";


			// Act
			var result = await _controller.PostDungemon(testDungemon);

			// Assert
			result.Should().BeOfType<UnauthorizedObjectResult>();
			var objectResult = result as UnauthorizedObjectResult;
			objectResult?.Value.Should().Be(expectedErrorMessage);
		}

		[Test]
		public async Task PatchDungemon_CorrectUser_ReturnsOkUpdatedDungemon()
		{
			// Arrange
			var testDungemon = _fixture.Create<Dungemon>();
			var testUserId = testDungemon.UserId;
			
			_mockJwtService
				.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
				.Returns(testUserId);

			_mockDungemonService
				.Setup(d => d.UpdateDungemon(testDungemon))
				.ReturnsAsync((testDungemon, "Success"));

			var expected = testDungemon;

			// Act
			var result = await _controller.PatchDungemon(testDungemon);

			// Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = result as OkObjectResult;
			objectResult?.Value.Should().Be(expected);
		}

		[Test]
		public async Task PatchDungemon_IncorrectUser_ReturnsUnauthorized()
		{
			// Arrange
			var testDungemon = _fixture.Create<Dungemon>();
			var testUserId = _fixture.Create<string>();
			while (testUserId == testDungemon.UserId)
			{
				testUserId = _fixture.Create<string>();
			}
			
			_mockJwtService
				.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
				.Returns(testUserId);

			var expectedErrorMessage = "You may not edit other users' Dungémon.";

			// Act
			var result = await _controller.PatchDungemon(testDungemon);

			// Assert
			result.Should().BeOfType<UnauthorizedObjectResult>();
			var objectResult = result as UnauthorizedObjectResult;
			objectResult?.Value.Should().Be(expectedErrorMessage);
		}

		[Test]
		public async Task DeleteDungemon_UserNotSignedIn_ReturnsUnauthorized()
		{
			// Arrange
			var testDungemon = _fixture.Create<Dungemon>();
			
			_mockJwtService
				.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
				.Returns(() => null);

			var expectedErrorMessage = "You must be signed-in to delete a Dungémon.";

			// Act
			var result = await _controller.DeleteDungemon(testDungemon.Id);

			// Assert
			result.Should().BeOfType<UnauthorizedObjectResult>();
			var objectResult = result as UnauthorizedObjectResult;
			objectResult?.Value.Should().Be(expectedErrorMessage);
		}

		[Test]
		public async Task DeleteDungemon_WrongUserSignedIn_ReturnsUnauthorized()
		{
			// Arrange
			var testDungemon = _fixture.Create<Dungemon>();
			var testUserId = _fixture.Create<string>();
			while (testUserId == testDungemon.UserId)
			{
				testUserId = _fixture.Create<string>();
			}

			_mockJwtService
				.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
				.Returns(() => testUserId);

			var expectedErrorMessage = "User Id and Dungémon User Id do not match.";
			_mockDungemonService
				.Setup(d => d.DeleteDungemonById(testDungemon.Id, testUserId))
				.ReturnsAsync(expectedErrorMessage);

			// Act
			var result = await _controller.DeleteDungemon(testDungemon.Id);

			// Assert
			result.Should().BeOfType<UnauthorizedObjectResult>();
			var objectResult = result as UnauthorizedObjectResult;
			objectResult?.Value.Should().Be(expectedErrorMessage);
		}

		[Test]
		public async Task DeleteDungemon_CorrectUserSignedIn_ReturnsNoContent()
		{
			// Arrange
			var testDungemonId = _fixture.Create<int>();
			var testUserId = _fixture.Create<string>();
			_mockJwtService
				.Setup(j => j.ValidateUserIdFromJwt(It.IsAny<HttpRequest>()))
				.Returns(testUserId);

			_mockDungemonService
				.Setup(d => d.DeleteDungemonById(testDungemonId, testUserId))
				.ReturnsAsync("Success");

			// Act
			var result = await _controller.DeleteDungemon(testDungemonId);

			// Assert
			result.Should().BeOfType<NoContentResult>();
		}
	}
}
