using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Repository
{
    public interface IClienteRepository
    {
        void Inserir(Cliente cliente);
        void Atualizar(Cliente cliente);
        List<Cliente> Buscar();
        Cliente Buscar(int id);
        Cliente Buscar(string email);
        void Deletar(int id);
    }

}

