using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Service
{
    public interface IUsuarioService
    {
        void Criar(Usuario user);
        string Logar(string email, string senha);
    }
}
