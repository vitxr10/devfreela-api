using DevFreela.Application.Commands.LoginUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async void LoginIsValid_Executed_ReturnLoginUserViewModel()
        {
            // Arrange
            var user = new User("Plinio Souza", "teste@email.com", "123456", DateTime.Now.AddYears(-20), "Freelancer");
            var passwordHash = "hashedPassword";
            var token = "generatedToken";

            var userRepositoryMock = Substitute.For<IUserRepository>();
            userRepositoryMock.GetByLoginAndPasswordAsync(Arg.Any<string>(), Arg.Any<string>()).Returns(user);

            var authServiceMock = Substitute.For<IAuthService>();
            authServiceMock.ComputeSha256Hash(Arg.Any<string>()).Returns(passwordHash);
            authServiceMock.GenerateJwtToken(Arg.Any<string>(), Arg.Any<string>()).Returns(token);

            var loginUserCommand = new LoginUserCommand();
            var loginUserCommandHandler = new LoginUserCommandHandler(authServiceMock, userRepositoryMock);

            // Act
            var loginUserViewModel = await loginUserCommandHandler.Handle(loginUserCommand, new CancellationToken());

            // Assert
            Assert.NotNull(loginUserViewModel);
            Assert.NotNull(loginUserViewModel.Email);
            Assert.NotEmpty(loginUserViewModel.Email);
            Assert.NotNull(loginUserViewModel.Token);
            Assert.NotEmpty(loginUserViewModel.Token);
            authServiceMock.Received(1).ComputeSha256Hash(Arg.Any<string>());
            await userRepositoryMock.Received(1).GetByLoginAndPasswordAsync(Arg.Any<string>(), Arg.Any<string>());
            authServiceMock.Received(1).GenerateJwtToken(Arg.Any<string>(), Arg.Any<string>());
        }
    }
}
