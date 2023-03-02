using FluentValidation;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Email).EmailAddress()
                                 .WithMessage("Email invalido");

            RuleFor(x => x.Senha).Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%¨&*()-_=+])[0-9a-zA-Z!@#$%¨&*()-_=+]{8,}$")
                                 .WithMessage("A senha deve conter ao menos um dígito, uma letra minúscula,uma letra maiúscula,um caractere especial e8 dos caracteres");
            ;
        }
    }
}
