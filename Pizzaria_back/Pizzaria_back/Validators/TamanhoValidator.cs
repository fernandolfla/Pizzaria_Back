using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    /*
        Os tamanhos precisam ter Nome com mais de 3 dígitos, uma quantidade de fatias e quantidade de sabores
        Caso o produto não seja fatiado ou com sabor diferente, adote 1
        Exemplo de Tamanhos: Broto, Média, Grande, Gigante, Big
        Tamanhos não são ligados a um produto, então podem ser cadastrados todos de uma vez
        Tamanhos serão ligados ao preço em Tipo_Tamanhos
     */
    public class TamanhoValidator : AbstractValidator<Tamanho>
    {
        public TamanhoValidator(ITamanhoRepository repository)
        {
            RuleFor(x => x.Nome).NotEmpty()
                             .NotNull().WithMessage("Tamanho precisa ter seu nome especificado")
                             .MinimumLength(3).WithMessage("O Tamanho deve conter no mínimo 3 letras");

            RuleFor(x => x.QtdFatias).NotEmpty().WithMessage("O tamanho precisa ter uma quantidade de fatias");

            RuleFor(x => x.QtdSabor).NotEmpty().WithMessage("O tamanho precisa ter uma quantidade de sabores");
        }
    }
}
