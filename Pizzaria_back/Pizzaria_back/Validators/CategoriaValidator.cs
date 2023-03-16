using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Resources;

namespace Pizzaria_back.Validators
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator(ICategoriaRepository repository)
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0).WithMessage(Resource.categoria_idInvalido);

            RuleFor(x => x.Nome).NotEmpty()
                             .NotNull().WithMessage(Resource.categoria_tamanhoInvalido)
                             .MinimumLength(3).WithMessage(Resource.categoria_tamanhomenor);

            RuleFor(x => x)
                .Must((x) =>
                {
                    if (repository.Buscar(x.Nome) && x.Id < 1) return false;
                    return true;
                }).WithMessage(Resource.categoria_nomeduplicado);
        }
    }
}
