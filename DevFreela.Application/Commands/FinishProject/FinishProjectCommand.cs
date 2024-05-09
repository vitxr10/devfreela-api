﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest
    {
        public FinishProjectCommand(int id)
        {
            Id = id;
        }

        public FinishProjectCommand()
        {
            
        }

        public int Id { get; set; }
    }
}
