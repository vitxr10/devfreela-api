using DevFreela.Application.DTOs;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand>
    {
        private readonly IPaymentService _paymentsService;
        private readonly IProjectRepository _projectRepository;
        public FinishProjectCommandHandler(IPaymentService paymentsService, IProjectRepository projectRepository)
        {
            _paymentsService = paymentsService;
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null)
                throw new DirectoryNotFoundException("Projeto não encontrado.");

            if (project.Status == Core.Enums.ProjectStatusEnum.InProgress)
                throw new Exception("Não é possível finalizar o projeto");

            var paymentInfo = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, request.Amount);

            _paymentsService.ProcessPayment(paymentInfo);

            project.SetPaymentPending();
            await _projectRepository.SaveAsync(); 

            return Unit.Value;
        }
    }
}
