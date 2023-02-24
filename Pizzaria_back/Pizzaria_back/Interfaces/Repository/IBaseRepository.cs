using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Inserir(T objeto);
        void Atualizar(T objeto);
        void Deletar(int id);
        List<T> Buscar();
        T? Buscar(int id);
        
    }
}
