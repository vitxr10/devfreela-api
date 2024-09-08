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
        private readonly IUnitOfWork _unitOfWork;
        public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.Users.GetByIdAsync(request.IdClient);

            if (client == null)
                throw new DirectoryNotFoundException("Cliente não encontrado");

            var freelancer = await _unitOfWork.Users.GetByIdAsync(request.IdFreelancer);

            if (freelancer == null)
                throw new DirectoryNotFoundException("Freelancer não encontrado");

            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            await _unitOfWork.Projects.InsertAsync(project);
            await _unitOfWork.CompleteAsync();

            return project.Id;
        }
    }
}
