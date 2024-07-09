using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var client = await _userRepository.GetByIdAsync(request.IdClient);

            if (client == null)
                throw new DirectoryNotFoundException("Cliente não encontrado");

            var freelancer = await _userRepository.GetByIdAsync(request.IdFreelancer);

            if (freelancer == null)
                throw new DirectoryNotFoundException("Freelancer não encontrado");

            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            await _projectRepository.InsertAsync(project);

            return project.Id;
        }
    }
}
