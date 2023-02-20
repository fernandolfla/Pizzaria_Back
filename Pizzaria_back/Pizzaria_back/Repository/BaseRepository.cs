using Microsoft.EntityFrameworkCore;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class BaseRepository<T> where T : DbEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Inserir(T objeto)
        {
            _applicationDbContext.Add(objeto);
            _applicationDbContext.SaveChanges();
        }
        public void Atualizar(T objeto)
        {
            var existingObj = _applicationDbContext.Set<T>().Find(objeto.Id);
            if (existingObj != null)
            {
                _applicationDbContext.Entry(existingObj).CurrentValues.SetValues(objeto);
                _applicationDbContext.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            var objeto = this.Buscar(id);
            if (objeto != null)
            { 
                objeto.Ativo = false;
                this.Atualizar(objeto);
            }
        }

        public List<T> Buscar()
            => _applicationDbContext.Set<T>()
                                    .Where(x => x.Ativo)
                                    .ToList();
        public T? Buscar(int id)
           => _applicationDbContext.Set<T>()
                .Where(x => x.Id == id && x.Ativo == true)
                .FirstOrDefault();

    }
}
