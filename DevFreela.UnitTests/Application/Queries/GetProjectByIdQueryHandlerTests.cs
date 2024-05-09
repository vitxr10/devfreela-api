using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task ProjectExists_Executed_ReturnProjectDetailsViewModel()
        {
            // Arrange
            var project = new Project("Project test", "Test", 1, 2, 5000);

            var projectRepositoryMock = Substitute.For<IProjectRepository>();
            projectRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(project);

            var getProjectQuery = new GetProjectQuery();
            var getProjectQueryHandler = new GetProjectQueryHandler(projectRepositoryMock);

            // Act
            var projectDetailsViewModel = await getProjectQueryHandler.Handle(getProjectQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectDetailsViewModel);
            await projectRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
        }
    }
}
