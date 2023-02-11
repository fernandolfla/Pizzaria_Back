using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

namespace Pizzaria_back.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository; 
        }

        public void Inserir(Cliente cliente)
        {
            CheckCliente(cliente);
            _clienteRepository.Inserir(cliente);
        }
        public void Atualizar(Cliente cliente)
        {
            CheckCliente(cliente);
            _clienteRepository.Atualizar(cliente);
        }
        public List<Cliente> Buscar()
          =>  _clienteRepository.Buscar();

        public Cliente Buscar(int id)
        => _clienteRepository.Buscar(id);

        public void Deletar(int id)
        => _clienteRepository.Deletar(id);


        private void CheckCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
                throw new BussinessException("Digite um nome para este cliente");

            if (cliente.Nome.Length < 3)
                throw new BussinessException("O nome deve conter no mínimo 3 letras");

            if (string.IsNullOrEmpty(cliente.Telefone))
                throw new BussinessException("Digite um Telefone Válido");
     
        }
    }
}
