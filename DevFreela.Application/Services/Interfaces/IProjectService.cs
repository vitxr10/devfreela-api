using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll();
        ProjectDetailsViewModel GetById(int id);
        int Create(CreateProjectInputModel inputModel);
        void CreateComment(int id, CreateCommentInputModel inputModel);
        void Update(int id, UpdateProjectInputModel inputModel);
        void Start(int id);
        void Finish(int id);
        void Delete(int id);
    }
}
