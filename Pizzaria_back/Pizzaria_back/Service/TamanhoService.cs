using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Repository;
using Pizzaria_back.Validators;

namespace Pizzaria_back.Service
{
    public class TamanhoService : BaseService<Tamanho>, ITamanhoService
    {
        private readonly ITamanhoRepository _repository;

        public TamanhoService(ITamanhoRepository repository) : base(repository)
        {
            _repository = repository;
        }


        public override bool ValidarInserir(Tamanho objeto)
        {
            TamanhoInserirValidator validations = new TamanhoInserirValidator(_repository);
            var validationResult = validations.Validate(objeto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(";", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new BussinessException(errors);
            }
            return true;
        }

        public override bool ValidarAtualizar(Tamanho objeto)
        {
            TamanhoAtualizarValidator validations = new TamanhoAtualizarValidator(_repository);
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
