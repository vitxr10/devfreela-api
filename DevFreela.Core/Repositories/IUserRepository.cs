﻿using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByLoginAndPasswordAsync(string login, string password);
        Task<User> GetByIdAsync(int id);
        Task<int> InsertAsync(User user);
        Task SaveAsync();
    }
}
