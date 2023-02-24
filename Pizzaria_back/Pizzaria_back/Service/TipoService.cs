using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Validators;

namespace Pizzaria_back.Service
{
    public class TipoService : BaseService<Tipo>, ITipoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ITipoRepository _tipoRepository;

        public TipoService(ITipoRepository tiporepository, IProdutoRepository produtoRepository) : base (tiporepository)
        {
            _produtoRepository = produtoRepository;
            _tipoRepository = tiporepository;
        }

        public override bool Validar(Tipo objeto)
        {
            TipoValidator validations = new TipoValidator(_produtoRepository);
            var validationResult = validations.Validate(objeto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(";", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new BussinessException(errors);
            }
            return true;
        }



    }
}