using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

namespace Pizzaria_back.Service
{
    public class TamanhoService : BaseService<Tamanho>, ITamanhoService
    {
        private readonly ITamanhoRepository _repository;

        public TamanhoService(ITamanhoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
