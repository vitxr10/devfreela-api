using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<ProjectViewModel> GetAll()
        {
            var projects = _dbContext.Projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.IdClient, p.IdFreelancer, p.TotalCost))
                .ToList();

            return projects;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            var projectDetailsViewModel = new ProjectDetailsViewModel(project.Title);

            return projectDetailsViewModel;
        }

        public int Create(CreateProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.Comments.Add(comment);
        }

        public void Update(int id, UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            project.Start();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            project.Finish();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            project.Delete();
        }
    }
}
