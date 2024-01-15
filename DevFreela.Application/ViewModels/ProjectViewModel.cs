using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, int idClient, int idFreelancer, decimal totalCost)
        {
            Id = id;
            Title = title;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
