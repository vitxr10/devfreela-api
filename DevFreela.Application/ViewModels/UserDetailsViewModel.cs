using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string fullName, string email, string role, DateTime birthDate, bool active)
        {
            FullName = fullName;
            Email = email;
            Role = role;
            BirthDate = birthDate;
            Active = active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; set; }
        //public List<UserSkill> Skills { get; private set; }
        //public List<Project> OwnedProjects { get; private set; }
        //public List<Project> FreelanceProjects { get; set; }
    }
}
