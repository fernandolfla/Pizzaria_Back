using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    /*
     * Para atualizar um sabor é necessario garantir o Id, garantir que ele existe no banco
     * Nome de 3 dígitos
     * Um tipo válido para atualizar, banco relacional não precisa verificar no banco a FK do Tipo
     */
    public class SaborAtualizarValidator : AbstractValidator<Sabor>
    {
        public SaborAtualizarValidator(ISaborRepository repository) 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Necessário Id Válido");

            RuleFor(x => x)
               .Must((x) =>
               {
                   return repository.Buscar(x.Id) != null;
               }).WithMessage("O sabor precisa existir para atualizar");

            RuleFor(x => x.Nome).NotEmpty()
                              .NotNull().WithMessage("Nome precisa ter seu nome especificado")
                              .MinimumLength(3).WithMessage("O Nome deve conter no mínimo 3 letras");

            RuleFor(x => x.TipoId).NotEmpty().WithMessage("Um Tipo válido é necessário para atualizar");
        }
    }
}
