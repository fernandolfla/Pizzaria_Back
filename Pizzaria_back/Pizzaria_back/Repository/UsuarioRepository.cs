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

        public Usuario? Buscar(string email, string senha)
            => _context.Usuarios.FirstOrDefault(x => x.Ativo && x.Email == email && x.Senha == senha);

        public void Criar(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }
    }
}
