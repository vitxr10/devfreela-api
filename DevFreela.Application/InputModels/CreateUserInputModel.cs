using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class CreateUserInputModel
    {
        public CreateUserInputModel(string fullName, string email, string password, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
