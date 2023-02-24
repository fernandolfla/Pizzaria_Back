using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class TipoRepository : BaseRepository<Tipo>, ITipoRepository 
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TipoRepository(ApplicationDbContext applicationDbContext) : base (applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;   
        }
    }
}
