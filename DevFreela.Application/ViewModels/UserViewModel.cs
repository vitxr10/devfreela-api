using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; set; }
    }
}
