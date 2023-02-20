using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Validators;

namespace Pizzaria_back.Service
{
    public class SaborService : BaseService<Sabor> , ISaborService
    {
        private readonly ISaborRepository _repository;

        public SaborService(ISaborRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override bool Validar(Sabor objeto)
        {
            SaborValidator validations = new SaborValidator(_repository);
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
