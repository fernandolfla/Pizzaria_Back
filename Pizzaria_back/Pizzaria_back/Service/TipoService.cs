using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

namespace Pizzaria_back.Service
{
    public class TipoService : BaseService<Tipo>, ITipoService
    {
        private readonly ITipoRepository _repository;

        public TipoService(ITipoRepository repository) : base (repository)
        {
            _repository = repository;
        }


    }
}