using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;
        public GetProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ProjectDetailsViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null)
                throw new DirectoryNotFoundException("Projeto não encontrado.");

            var projectDetailsViewModel = new ProjectDetailsViewModel
                (
                    project.Title,
                    project.Description,
                    project.IdClient,
                    project.IdFreelancer,
                    project.TotalCost,
                    project.StartedAt,
                    project.FinishedAt,
                    project.Status
                );

            return projectDetailsViewModel;
        }
    }
}
