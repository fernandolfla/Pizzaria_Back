using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

namespace Pizzaria_back.Service
{
    public class Tipo_TamanhoService : BaseService<Tipo_Tamanho>, ITipo_TamanhoService
    {
        private readonly ITipo_TamanhoRepository _repository;

        public Tipo_TamanhoService(ITipo_TamanhoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
