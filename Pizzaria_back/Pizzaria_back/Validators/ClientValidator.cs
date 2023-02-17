using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Repository;

namespace Pizzaria_back.Validators
{
    public class ClientValidator : AbstractValidator<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        private string email;
        public ClientValidator(IClienteRepository clienteRepository)
        {

            _clienteRepository = clienteRepository;

            RuleFor(x => x.Nome).NotEmpty()
                                .NotNull().WithMessage("Digite um nome para este cliente")
                                .MinimumLength(3).WithMessage("O nome deve conter no mínimo 3 letras");

            RuleFor(x => x.Telefone).NotEmpty()
                                    .NotNull().WithMessage("Digite um Telefone Válido.");

            RuleFor(x => x.Email).NotNull().WithMessage("O email não pode ser nulo");

            RuleFor(x => x)
                .Custom((x, context) =>
                {
                    this.email = x.Email;
                });

            if (!string.IsNullOrEmpty(email))
                RuleFor(x => x.Email)
                    .Equal(_clienteRepository.Buscar(email).Email)
                    .WithMessage("não é possível registrar o mesmo e-mail");

        }

       
    }
}
