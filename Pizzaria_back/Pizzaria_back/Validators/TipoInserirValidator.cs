using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    /*
     O tipo precisa ter um nome com mais de 3 letras e precisa ter um produto com "Fracionado" verdadeiro para usar de FK
     Pode haver quantos tipos quiser por produto, todo produto fracionado pode ter tipos
     Exemplos de tipos: Tradicional, Especial, Gourmet, Doces
    */
    public class TipoInserirValidator : AbstractValidator<Tipo>
    {
        public TipoInserirValidator(IProdutoRepository repository)
        {
            RuleFor(x => x.ProdutoId).NotEmpty().WithMessage("Um produto válido é necessário para cadastrar um tipo");

            RuleFor(x => x.Nome).NotEmpty()
                              .NotNull().WithMessage("Tipo precisa ter seu nome especificado")
                              .MinimumLength(3).WithMessage("O Tipo deve conter no mínimo 3 letras");

            RuleFor(x => x)
               .Must((x) =>
               {
                   return repository.Buscar(x.ProdutoId) != null;
               }).WithMessage("Um produto precisa existir para cadastrar seu tipo");

            RuleFor(x => x)
               .Must((x) =>
               {
                   return repository.Buscar(x.ProdutoId).Fracionado == true;
               }).WithMessage("O produto precisa ser marcado como fracionado");




        }


    }
}
