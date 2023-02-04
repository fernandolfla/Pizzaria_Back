using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private List<Produto> _produtos;

        public ProdutoRepository()
        {
            _produtos = new List<Produto>();
        }

        public void Atualizar(Produto produto)
        {
            var produtoLista = _produtos.FirstOrDefault(x => x.Id == produto.Id);
            if(produtoLista != null)
            {
                _produtos.Remove(produtoLista);
                _produtos.Add(produto);
            }
        }

        public List<Produto> Buscar()
        {
            return _produtos;
        }

        public Produto Buscar(int id)
        {
            return _produtos.FirstOrDefault(x => x.Id == id);
        }

        public void Deletar(int id)
        {
            var produtoLista = _produtos.FirstOrDefault(x => x.Id == id);
            if (produtoLista != null)
            {
                _produtos.Remove(produtoLista);
            }
        }

        public void Inserir(Produto produto)
        {
            _produtos.Add(produto);
        }
    }
}
