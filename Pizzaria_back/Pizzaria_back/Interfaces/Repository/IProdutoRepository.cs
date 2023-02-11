using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        List<Produto> Buscar();
        Produto Buscar(int id);
        void Inserir(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(int id);
    }
}
