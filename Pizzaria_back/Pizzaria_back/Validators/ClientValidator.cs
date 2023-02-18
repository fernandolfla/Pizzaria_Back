using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Repository;

namespace Pizzaria_back.Validators
{
    public class ClientValidator : AbstractValidator<Cliente>
    {
        public ClientValidator(IClienteRepository clienteRepository)
        {   

            RuleFor(x => x.Nome).NotEmpty()
                                .NotNull().WithMessage("Digite um nome para este cliente")
                                .MinimumLength(3).WithMessage("O nome deve conter no mínimo 3 letras");

            RuleFor(x => x.Telefone).NotEmpty()
                                    .NotNull().WithMessage("Digite um Telefone Válido.");
            RuleFor(x => x)
                .Must((x) =>
                {
                    return clienteRepository.Buscar(x.Email) == null;
                }).WithMessage("não é possível registrar o mesmo e-mail");

            

        }

       
    }
}
