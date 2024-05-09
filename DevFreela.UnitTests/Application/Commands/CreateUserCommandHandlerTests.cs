using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Auth;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            // Arrange
            var createUserCommand = new CreateUserCommand("Plinio Silva", "teste@email.com", "123456", DateTime.Now.AddYears(-20), "Freelancer");
            var passwordHash = "hashedPassword";

            var userRepositoryMock = Substitute.For<IUserRepository>();

            var authServiceMock = Substitute.For<IAuthService>();
            authServiceMock.ComputeSha256Hash(Arg.Any<string>()).Returns(passwordHash);

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock, authServiceMock);

            // Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);
            authServiceMock.Received(1).ComputeSha256Hash(Arg.Any<string>());
            await userRepositoryMock.Received(1).InsertAsync(Arg.Any<User>());
        }
    }
}
