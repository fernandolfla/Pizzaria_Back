using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class SaborRepository : BaseRepository<Sabor>, ISaborRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SaborRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }


    }
}
