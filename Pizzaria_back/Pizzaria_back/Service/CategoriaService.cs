using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Validators;

namespace Pizzaria_back.Service
{
    public class CategoriaService : BaseService<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override bool Validar(Categoria objeto)
        {
            CategoriaValidator validations = new CategoriaValidator(_repository);
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
