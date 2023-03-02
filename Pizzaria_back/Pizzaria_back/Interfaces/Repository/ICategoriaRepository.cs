using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Repository
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        bool Buscar(string nome);
        List<Categoria> BuscarTudo();

    }
}
