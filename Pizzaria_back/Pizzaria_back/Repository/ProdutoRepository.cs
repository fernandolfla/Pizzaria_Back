using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProdutoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Inserir(Produto produto)
        {
            _applicationDbContext.Produtos.Add(produto);
            _applicationDbContext.SaveChanges();
        }
        public void Atualizar(Produto produto)
        {
            _applicationDbContext.Produtos.Update(produto);
            _applicationDbContext.SaveChanges();
        }

        public List<Produto> Buscar()
            => _applicationDbContext.Produtos
                                    .Where(x => x.Ativo)
                                    .ToList();

        public Produto Buscar(int id)
            => _applicationDbContext.Produtos.FirstOrDefault(x => x.Id == id && x.Ativo);

        public void Deletar(int id)
        {
            var produto = this.Buscar(id);
            produto.Ativo = false;
            this.Atualizar(produto);
        }

        
    }
}
