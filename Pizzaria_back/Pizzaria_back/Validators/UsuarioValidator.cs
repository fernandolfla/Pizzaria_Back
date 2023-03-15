using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Resources;

namespace Pizzaria_back.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator(IUsuarioRepository usuarioRepository, bool eLogin)
        {
            RuleFor(x => x.Email).EmailAddress()
                                 .WithMessage(Resource.usario_emailInvalido);

            RuleFor(x => x.Senha).Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%¨&*()-+])[0-9a-zA-Z!@#$%¨&*()-+]{8,}$")
                                 .WithMessage(Resource.usario_senhaInvalida);

            if (!eLogin)
                RuleFor(x => x.Email).Must((email) => !usuarioRepository.Buscar().Any(x => x.Ativo && x.Email == email))
                                     .WithMessage(Resource.usuario_emailduplicado);
        }
    }
}
