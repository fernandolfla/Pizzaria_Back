using Pizzaria_back.Interfaces.Repository;

namespace Pizzaria_back.Service
{
    public class BaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Inserir(T objeto)
        {
            if(Validar(objeto))
                _baseRepository.Inserir(objeto);
        }

        public void Atualizar(T objeto)
        {
            if (Validar(objeto))
                _baseRepository.Atualizar(objeto);
        }
        public void Deletar(int id)
        {
            if(Buscar(id) != null)
                _baseRepository.Deletar(id);
        }
        public List<T> Buscar()
          => _baseRepository.Buscar();

        public T? Buscar(int id)
        => _baseRepository.Buscar(id);

        public virtual bool Validar(T objeto) //Cada método sobrescreve seu validar
        => true;


    }
    

    
}
