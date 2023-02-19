using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class TamanhoRepository : BaseRepository<Tamanho>, ITamanhoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TamanhoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
