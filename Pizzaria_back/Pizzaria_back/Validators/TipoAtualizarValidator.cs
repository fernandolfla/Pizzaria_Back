using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    /*
         Para atualizar um Tipo é necessário possuir um Id e ele precisa conter um objeto no banco
         O nome precisa ter 3 dígitos
         O produtoId precisa existir, não há necessidade de verificar no banco pois é um FK que veio
         Não necessita verificar se o produto é fracionado pois uma vez fracionado não pode se mudar no banco
      */
    public class TipoAtualizarValidator : AbstractValidator<Tipo>
    {
        public TipoAtualizarValidator(ITipoRepository repository) 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Necessário um Id Válido");

            RuleFor(x => x)
               .Must((x) =>
               {
                   return repository.Buscar(x.Id) != null;
               }).WithMessage("O Tipo precisa existir para atualizar");

            RuleFor(x => x.Nome).NotEmpty()
                              .NotNull().WithMessage("Nome precisa ter seu nome especificado")
                              .MinimumLength(3).WithMessage("O Nome deve conter no mínimo 3 letras");

            RuleFor(x => x.ProdutoId).NotEmpty().WithMessage("Um produto válido é necessário para cadastrar um tipo");

        }
    }
}
