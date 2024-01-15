using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserViewModel> GetAll()
        {
            var users = _dbContext.Users.Select(u => new UserViewModel(u.FullName)).ToList();

            return users;
        }

        public UserDetailsViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            var userDetailsViewModel = new UserDetailsViewModel(user.FullName);

            return userDetailsViewModel;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);

            return user.Id;
        }

        public void UpdateLogin(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public void Update(int id, UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            _dbContext.Users.Remove(user);
        }
    }
}
