using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Service
{
    public interface ICategoriaService : IBaseService<Categoria>
    {
        List<Categoria> BuscarTudo();
    }
}
