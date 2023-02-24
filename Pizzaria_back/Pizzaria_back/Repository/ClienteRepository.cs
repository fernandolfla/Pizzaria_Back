using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;

namespace Pizzaria_back.Repository
{
    public class ClienteRepository :IClienteRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ClienteRepository(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Inserir(Cliente cliente) 
        {
            _applicationDbContext.Add(cliente);
            _applicationDbContext.SaveChanges();
        }
        public void Atualizar(Cliente cliente) 
        {
            _applicationDbContext.Update(cliente);
            _applicationDbContext.SaveChanges();
        }
        public List<Cliente> Buscar() 
        => _applicationDbContext.Clientes
                        .Where(x => x.Ativo)
                        .ToList();

        public Cliente Buscar(int Id) 
            => _applicationDbContext.Clientes
                         .FirstOrDefault(x => x.Id == Id);

        public Cliente Buscar(string email)  //cliente não podem ter o mesmo e-mail cadastrado 
            => _applicationDbContext.Clientes
                         .FirstOrDefault(x => x.Email.Equals(email));

        public Cliente BuscarPhone(string phone)  //cliente não podem ter o mesmo e-mail cadastrado 
            => _applicationDbContext.Clientes
                         .FirstOrDefault(x => x.Telefone.Equals(phone));


        public void Deletar(int id) 
        {
            var cliente = this.Buscar(id);
            cliente.Ativo = false;
            this.Atualizar(cliente);
        }


    }
}
