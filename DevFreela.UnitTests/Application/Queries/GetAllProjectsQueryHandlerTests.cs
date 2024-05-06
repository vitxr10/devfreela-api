using DevFreela.Application.Queries.GetAllProjects;
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
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExists_Executed_ReturnThreeProjectViewModel()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Project test 1", "Test 1", 1, 2, 5000),
                new Project("Project test 2", "Test 2", 3, 4, 6000),
                new Project("Project test 3  ", "Test 3", 5, 6, 7000)
            };

            var projectRepositoryMock = Substitute.For<IProjectRepository>();
            projectRepositoryMock.GetAllAsync().Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery();
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock);

            // Act
            var projectsViewModel = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectsViewModel);
            Assert.NotEmpty(projectsViewModel);
            Assert.Equal(projectsViewModel.Count, projects.Count);
            await projectRepositoryMock.Received(1).GetAllAsync();
        }
    }
}
