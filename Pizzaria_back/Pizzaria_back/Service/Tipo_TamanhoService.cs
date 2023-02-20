using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Repository;
using Pizzaria_back.Validators;

namespace Pizzaria_back.Service
{
    public class Tipo_TamanhoService : BaseService<Tipo_Tamanho>, ITipo_TamanhoService
    {
        private readonly ITipo_TamanhoRepository _tipo_TamanhoRepository;
        private readonly ITipoRepository _tipoRepository;
        private readonly ITamanhoRepository _tamanhoRepository;

        public Tipo_TamanhoService(ITipo_TamanhoRepository tipo_TamanhoRepository, ITipoRepository tipoRepository, ITamanhoRepository tamanhoRepository) : base(tipo_TamanhoRepository)
        {
            _tipo_TamanhoRepository = tipo_TamanhoRepository;
            _tipoRepository = tipoRepository;
            _tamanhoRepository = tamanhoRepository;
        }

        public override bool Validar(Tipo_Tamanho objeto)
        {
            Tipo_TamanhoValidator validations = new Tipo_TamanhoValidator(_tipo_TamanhoRepository, _tamanhoRepository,_tipoRepository);
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
