using DevFreela.Core.Entities;
using DevFreela.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<PaginationResult<Project>> GetAllAsync(string? stringQuery, int page);
        Task<Project> GetByIdAsync(int id);
        Task InsertAsync(Project project);
        Task InsertCommentAsync(ProjectComment comment);
        Task SaveAsync();
    }
}
