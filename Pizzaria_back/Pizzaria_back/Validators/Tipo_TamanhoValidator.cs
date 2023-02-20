using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Validators
{
    public class Tipo_TamanhoValidator : AbstractValidator<Tipo_Tamanho>
    {
        /*
            Tipo_Tamanho é a tabela onde são registratos os preços dos produtos fracionados de acordo com Tipo e Tamanho de cada
            Tipo_Tamanho Precisa de um Tipo e um Tamanho existente como FK
            Tipo_Tamanho Precisa de um preço
            Tipo_Tamanho não pode ter o mesmo Tipo e Mesmo Tamanho duplicado cadastrados
            Não precisa verificar por produto, somente por tipo/tamanho, pois o segundo produto cadastrado terá tipos com ID novos
         */
        public Tipo_TamanhoValidator(ITipo_TamanhoRepository tipo_TamanhoRepository, ITamanhoRepository tamanhoRepository, ITipoRepository tipoRepository) 
        {

            RuleFor(x => x.TipoId).NotEmpty().WithMessage("Para cadastrar um preço ao produto fracionado é necessário um Tipo");

            RuleFor(x => x.TamanhoId).NotEmpty().WithMessage("Para cadastrar um preço ao produto fracionado é necessário um Tamanho");

            RuleFor(x => x.Preco).NotEmpty().WithMessage("Defina um preço para o produto");

            RuleFor(x => x)
             .Must((x) =>
             {
                
                 if (tipoRepository.Buscar(x.TipoId) != null)
                     if (tamanhoRepository.Buscar(x.TamanhoId) != null)
                         return false; 
                 return true;
             }).WithMessage("Não podemos cadastrar o mesmo preço para tipos e tamanhos iguais");
        }
    }
}
