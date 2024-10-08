﻿using DevFreela.Application.ViewModels;
using DevFreela.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<PaginationResult<ProjectViewModel>>
    {
        public string? StringQuery { get; set; }
        public int Page { get; set; } = 1;
    }
}
