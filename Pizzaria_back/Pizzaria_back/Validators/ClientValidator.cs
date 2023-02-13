using FluentValidation;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    public class ClientValidator : AbstractValidator<Cliente>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Nome).NotEmpty()
                                .NotNull().WithMessage("Digite um nome para este cliente")
                                .MinimumLength(3).WithMessage("O nome deve conter no mínimo 3 letras");

            RuleFor(x => x.Telefone).NotEmpty()
                                    .NotNull().WithMessage("Digite um Telefone Válido.");
        }
    }
}
