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
            if(ValidarInserir(objeto))
                _baseRepository.Inserir(objeto);
        }

        public void Atualizar(T objeto)
        {
            if (ValidarAtualizar(objeto))
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

        public virtual bool ValidarInserir(T objeto) //Cada método sobrescreve seu validar
        => true;

        public virtual bool ValidarAtualizar(T objeto)
        => true;



    }
    

    
}
