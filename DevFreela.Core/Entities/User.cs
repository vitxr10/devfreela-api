﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string password, DateTime birthDate, string role)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
            Active = true;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
            Role = role;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string? Password { get; private set; }
        public string Role { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; set; }
        public List<UserSkill> Skills { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }

        public void Update(string email)
        {
            Email = email;
        }

        public void Delete()
        {
            Active = false;
        }
    }
}
