using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.FullName)
                .NotNull()
                .WithMessage("O preenchimento do nome é obrigatório!")
                .NotEmpty()
                .WithMessage("O preenchimento do nome é obrigatório!");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Endereço de email inválido!");

            RuleFor(u => u.Password)
                .Must(IsValidPassword)
                .WithMessage("A senha deve ter 8 dígitos, letras maiúsculas e minúsculas, e caracteres especiais.");

            //RuleFor(u => u.BirthDate)
            //    .NotNull()
            //    .WithMessage("O preenchimento da senha é obrigatório!")
            //    .GreaterThanOrEqualTo(DateTime.Now)
            //    .WithMessage("Sua data de nascimento não pode ser hoje!");


        }

        public static bool IsValidPassword(string password)
        {
            // verifica se tem 8 caracteres, letras maiúsculas e minúsculas e caracteres especiais
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
