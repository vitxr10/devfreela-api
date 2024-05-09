using DevFreela.Application.Commands.CreateComment;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        [Fact]
        public async void InputDataIsOk_Executed_CreateComment()
        {
            // Arrange
            var projectRepositoryMock = Substitute.For<IProjectRepository>();

            var createCommentCommand = new CreateCommentCommand("Muito bom", 1, 2);
            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepositoryMock);

            // Act
            await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

            // Assert
            await projectRepositoryMock.Received(1).InsertCommentAsync(Arg.Any<ProjectComment>());
        }
    }
}
