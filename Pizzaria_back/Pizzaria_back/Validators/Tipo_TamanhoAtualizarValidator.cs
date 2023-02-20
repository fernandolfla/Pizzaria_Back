using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{  //Necessário existir no banco, conter TipoId e TamanhoId Fk e um Preço, que pode ser 0, mas não pode ser negativo
    public class Tipo_TamanhoAtualizarValidator: AbstractValidator<Tipo_Tamanho>
    {
        public Tipo_TamanhoAtualizarValidator(ITipo_TamanhoRepository repository)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Necessário Id Válido");

            RuleFor(x => x)
               .Must((x) =>
               {
                   return repository.Buscar(x.Id) != null;
               }).WithMessage("Pprecisa existir para atualizar");

            RuleFor(x => x.TipoId).NotEmpty().WithMessage("Um Tipo válido é necessário para atualizar");

            RuleFor(x => x.TamanhoId).NotEmpty().WithMessage("Um Tamanho válido é necessário para atualizar");

            RuleFor(x => x.Preco).NotEmpty().WithMessage("Um Preço válido é necessário para atualizar");

            RuleFor(x => x.Preco).LessThan(0).WithMessage("Preço não pode ser negativo");
        }
    }
}
