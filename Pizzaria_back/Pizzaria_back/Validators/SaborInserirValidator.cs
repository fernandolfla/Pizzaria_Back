using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    /*
        Sabores precisam de um nome com 3 dígitos e um Tipo cadastrado como FK
        São ligados ao tipo pois cada Tipo dita o preço de vários sabores
        Exemplo de sabores: Muzzarela, Calabresa....
     */
    public class SaborInserirValidator : AbstractValidator<Sabor>
    {
        public SaborInserirValidator(ISaborRepository repository)
        {
            RuleFor(x => x.Nome).NotEmpty()
                            .NotNull().WithMessage("Sabor precisa ter seu nome especificado")
                            .MinimumLength(3).WithMessage("O Sabor deve conter no mínimo 3 letras");

            RuleFor(x => x.TipoId).NotEmpty().WithMessage("Para cadastrar um Sabor ao produto fracionado é necessário um Tipo");


        }
    }
}
