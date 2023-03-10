using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator(IUsuarioRepository usuarioRepository)
        {
            RuleFor(x => x.Email).EmailAddress()
                                 .WithMessage("Email invalido");

            RuleFor(x => x.Senha).Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%¨&*()-+])[0-9a-zA-Z!@#$%¨&*()-+]{8,}$")
                                 .WithMessage("A senha deve conter ao menos um dígito, uma letra minúscula,uma letra maiúscula,um caractere especial e 8 dos caracteres");

            RuleFor(x => x.Email).Must((email) => !usuarioRepository.Buscar().Any(x => x.Ativo && x.Email == email))
                                 .WithMessage("Não é possivel cadastrar uma conta para este email.");
        }
    }
}
