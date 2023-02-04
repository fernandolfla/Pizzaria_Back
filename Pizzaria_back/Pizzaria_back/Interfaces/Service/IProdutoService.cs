using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Service
{
    public interface IProdutoService
    {
        List<Produto> Buscar();
        Produto Buscar(int id);
        void Inserir(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(int id);
    }
}
