using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Service
{
    public interface IProdutoService
    {
        void Inserir(Produto produto);
        void Atualizar(Produto produto);
        List<Produto> Buscar();
        Produto Buscar(int id);
        void Deletar(int id);
    }
}
