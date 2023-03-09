using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Criar(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public IQueryable<Usuario> Buscar()
        {
            return _context.Usuarios;
        }
    }
}
