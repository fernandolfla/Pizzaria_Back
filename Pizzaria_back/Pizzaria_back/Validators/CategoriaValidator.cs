using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator(ICategoriaRepository repository)
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0).WithMessage("Id com erro");

            RuleFor(x => x.Nome).NotEmpty()
                             .NotNull().WithMessage("Tamanho precisa ter seu nome especificado")
                             .MinimumLength(3).WithMessage("O Tamanho deve conter no mínimo 3 letras");

            RuleFor(x => x)
                .Must((x) =>
                {
                    if (repository.Buscar(x.Nome) && x.Id < 1) return false;
                    return true;
                }).WithMessage("não é possível registrar a mesmo categoria");
        }
    }
}
