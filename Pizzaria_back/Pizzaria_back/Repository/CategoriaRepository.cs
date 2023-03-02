using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoriaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Categoria? Buscar(string nome)  //categoria não podem ser iguais
            => _applicationDbContext.Categorias
                         .FirstOrDefault(x => x.Nome.Equals(nome));
        public Categoria? Buscar(bool ativo, int id) 
        => _applicationDbContext.Categorias
            .Where(x => x.Id == id)
            .FirstOrDefault();

        public List<Categoria> BuscarTudo()
              => _applicationDbContext.Categorias.ToList();

    }
}
