using DevFreela.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DevFreelaDbContext _dbContext;
        public UnitOfWork(DevFreelaDbContext dbContext, IProjectRepository projects, IUserRepository users)
        {
            _dbContext = dbContext;
            Projects = projects;
            Users = users;
        }

        public IProjectRepository Projects { get; }
        public IUserRepository Users { get; }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
