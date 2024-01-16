using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class UpdateProjectInputModel
    {
        public UpdateProjectInputModel(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
