using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Repository;

namespace Pizzaria_back.Validators
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator(ICategoriaRepository repository)
        {
            RuleFor(x => x.Nome).NotEmpty()
                             .NotNull().WithMessage("Tamanho precisa ter seu nome especificado")
                             .MinimumLength(3).WithMessage("O Tamanho deve conter no mínimo 3 letras");

            RuleFor(x => x)
                .Must((x) =>
                {
                    var categoria = repository.Buscar(x.Nome);
                    if (categoria != null && categoria.Id == x.Id) return true;
                    return categoria == null;
                }).WithMessage("não é possível registrar a mesmo categoria");
        }
    }
}
