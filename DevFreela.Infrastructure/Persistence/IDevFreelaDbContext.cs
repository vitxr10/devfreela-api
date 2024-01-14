using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public interface IDevFreelaDbContext
    {
        List<ProjectComment> Comments { get; set; }
        List<Project> Projects { get; set; }
        List<Skill> Skills { get; set; }
        List<User> Users { get; set; }
    }
}