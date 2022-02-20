using Moq;
using NUnit.Framework;
using RYB.Business;
using RYB.MediatR.Commands;
using RYB.Model.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RYB.MediatR.Tests;

public class UserCommandHandlerTests
{
    GetUserHandler getUserHandler;
    Mock<IUserRepo> userRepoMock;
    public UserCommandHandlerTests()
    {
        userRepoMock = new Mock<IUserRepo>();
        getUserHandler = new GetUserHandler(userRepoMock.Object);

    }
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        // arrange
        IEnumerable<UserProfile> users = new List<UserProfile>();
        userRepoMock.Setup(x => x.GetUsers()).ReturnsAsync(users);

        // act
        Task<IEnumerable<UserProfile>> usersData = getUserHandler.Handle(new Queries.GetUsers(), default(System.Threading.CancellationToken));
    }
}
