using DevFreela.Application.ViewModels;
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

namespace DevFreela.Application.Queries.Project.GetProjectById
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetProjectQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProjectDetailsViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

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
