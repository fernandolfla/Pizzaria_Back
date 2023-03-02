using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Repository
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Categoria Buscar(string nome);
        Categoria Buscar(bool ativo, int id);
        List<Categoria> BuscarTudo();

    }
}
