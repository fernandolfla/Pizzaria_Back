using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

namespace Pizzaria_back.Service
{
    public class SaborService : BaseService<Sabor> , ISaborService
    {
        private readonly ISaborRepository _repository;

        public SaborService(ISaborRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
