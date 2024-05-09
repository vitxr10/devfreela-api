using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public async Task ProjectIsCreated_Executed_StartProject()
        {
            // Arrange
            var project = new Project("Project test", "Test if starts", 1, 2, 5000);

            var projectRepositoryMock = Substitute.For<IProjectRepository>();
            projectRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(project);

            var startProjectCommand = new StartProjectCommand();
            var startProjectCommandHandler = new StartProjectCommandHandler(projectRepositoryMock);

            // Act
            await startProjectCommandHandler.Handle(startProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
            await projectRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await projectRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async Task ProjectIsInProgress_Executed_FinishProject()
        {
            // Arrange
            var project = new Project("Project test", "Test if finishes", 1, 2, 5000);

            var projectRepositoryMock = Substitute.For<IProjectRepository>();
            projectRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(project);

            var finishProjectCommand = new FinishProjectCommand();
            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepositoryMock);

            // Act
            await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(ProjectStatusEnum.Finished, project.Status);
            Assert.NotNull(project.FinishedAt);
            await projectRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await projectRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async Task ProjectExists_Executed_DeleteProject()
        {
            // Arrange
            var project = new Project("Project test", "Test if finishes", 1, 2, 5000);

            var projectRepositoryMock = Substitute.For<IProjectRepository>();
            projectRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(project);

            var deleteProjectCommand = new DeleteProjectCommand();
            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepositoryMock);

            // Act
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());

            // Assert
            Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);
            Assert.NotNull(project.UpdatedAt);
            await projectRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await projectRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async Task ProjectExists_Executed_UpdateProject()
        {
            // Arrange
            var project = new Project("Project test", "Test if finishes", 1, 2, 5000);

            var projectRepositoryMock = Substitute.For<IProjectRepository>();
            projectRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(project);

            var updateProjectCommand = new UpdateProjectCommand();
            var updateProjectCommandHandler = new UpdateProjectCommandHandler(projectRepositoryMock);

            // Act
            await updateProjectCommandHandler.Handle(updateProjectCommand, new CancellationToken());

            // Assert
            Assert.NotNull(project.UpdatedAt);
            await projectRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await projectRepositoryMock.Received(1).SaveAsync();
        }
    }
}
