using DevFreela.Application.ViewModels;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly DevFreelaDbContext _dbContext;

        public LoginUserCommandHandler(IAuthService authService, DevFreelaDbContext dbContext)
        {
            _authService = authService;
            _dbContext = dbContext;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == request.Email && u.Password == passwordHash);
            if (user == null)
                throw new Exception("Login e/ou senha inválidos.");

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
