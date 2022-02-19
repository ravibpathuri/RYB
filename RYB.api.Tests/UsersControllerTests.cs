using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RYB.api.Controllers;
using RYB.Model.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RYB.api.Tests
{
    public class UsersControllerTests
    {
        private UsersController usersController;
        private Mock<IMediator> mediatRMock;

        public UsersControllerTests()
        {
            mediatRMock = new Mock<IMediator>();
            usersController = new UsersController(mediatRMock.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetUsers_should_return_Ok_result()
        {
            // arrange
            IEnumerable<User> expectedData = new List<User> {
            new User {Email ="test@email.com"}
            };
            mediatRMock.Setup(x => x.Send(It.IsAny<MediatR.Queries.GetUsers>(), default(System.Threading.CancellationToken))).ReturnsAsync(expectedData);

            // act
            Task<IActionResult> actionResult = usersController.GetUsers();
            actionResult.Wait();

            OkObjectResult okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            IEnumerable<User> actualData = okObjectResult.Value as IEnumerable<User>;
            Assert.NotNull(actualData);

            // assert
            Assert.AreEqual(expectedData.First().Email, actualData.First().Email);

        }
    }
}