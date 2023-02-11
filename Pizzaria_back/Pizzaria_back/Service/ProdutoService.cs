using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

namespace Pizzaria_back.Service
{
    public class ProdutoService: IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)  //Controi o ProdutoRepository, conhece a interface 
        {
            _produtoRepository = produtoRepository;
        }

        public List<Produto> Buscar()
            => _produtoRepository.Buscar();

        public void Inserir(Produto produto)
        {
            if(_produtoRepository.Buscar(produto.Id) != null)
                throw new BussinessException("Produto duplicado");

            if (produto.Preco <= 0)
                throw new BussinessException("Digite o preço do produto");

            if (string.IsNullOrEmpty(produto.Nome))
                throw new BussinessException("Digite o nome do produto");

            _produtoRepository.Inserir(produto);
        }

        public void Atualizar(Produto produto)
        {
            if (produto.Id <= 0)
                throw new BussinessException("Informe um produto valido");

            if (produto.Preco <= 0)
                throw new BussinessException("Digite o preço do produto");

            if (string.IsNullOrEmpty(produto.Nome))
                throw new BussinessException("Digite o nome do produto");

            _produtoRepository.Atualizar(produto);
        }

        public void Deletar(int id)
            => _produtoRepository.Deletar(id);

        public Produto Buscar(int id)
        {
            return _produtoRepository.Buscar(id);
        }
    }
}
