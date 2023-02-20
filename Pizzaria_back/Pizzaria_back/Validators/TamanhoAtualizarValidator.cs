using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    //Para atualizar o tamanho, precisa existir no banco e nome maior que 3 dígitos
    public class TamanhoAtualizarValidator : AbstractValidator<Tamanho>
    {
        public TamanhoAtualizarValidator(ITamanhoRepository repository)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Necessário Id Válido");

            RuleFor(x => x)
               .Must((x) =>
               {
                   return repository.Buscar(x.Id) != null;
               }).WithMessage("Precisa existir para atualizar");

            RuleFor(x => x.Nome).NotEmpty()
                              .NotNull().WithMessage("Nome precisa ter seu nome especificado")
                              .MinimumLength(3).WithMessage("O Nome deve conter no mínimo 3 letras");

        }
    }
}
