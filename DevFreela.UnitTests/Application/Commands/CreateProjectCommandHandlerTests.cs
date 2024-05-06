﻿using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepositoryMock = Substitute.For<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Teste",
                Description = "Teste",
                IdClient = 1,
                IdFreelancer = 2,
                TotalCost = 5000
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock);

            // Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);
            await projectRepositoryMock.Received(1).InsertAsync(Arg.Any<Project>());
        }
    }
}
