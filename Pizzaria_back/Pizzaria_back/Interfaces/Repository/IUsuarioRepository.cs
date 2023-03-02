using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        void Criar(Usuario user);
        Usuario? Buscar(string email, string senha);
    }
}
