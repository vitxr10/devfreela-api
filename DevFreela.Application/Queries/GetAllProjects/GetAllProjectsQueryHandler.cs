﻿using DevFreela.Application.ViewModels;
using DevFreela.Core.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, PaginationResult<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;
        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<PaginationResult<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var paginationProjects = await _projectRepository.GetAllAsync(request.StringQuery, request.Page);

            var projectsViewModel = paginationProjects
                .Data
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.IdClient, p.IdFreelancer, p.TotalCost))
                .ToList();

            var paginationProjectsViewModel = new PaginationResult<ProjectViewModel>(
               paginationProjects.Page,
               paginationProjects.TotalPages,
               paginationProjects.PageSize,
               paginationProjects.ItemsCount,
               projectsViewModel
            );

            return paginationProjectsViewModel;
        }
    }
}
