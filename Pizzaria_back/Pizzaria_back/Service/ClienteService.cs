using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Validators;

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
            if(CheckCliente(cliente))
                _clienteRepository.Inserir(cliente);
        }
        public void Atualizar(Cliente cliente)
        {
            if (CheckCliente(cliente) && ClienteExists(cliente.Id))
                _clienteRepository.Atualizar(cliente);
        }
        public List<Cliente> Buscar()
          =>  _clienteRepository.Buscar();

        public Cliente Buscar(int id) {
           if(ClienteExists(id)) return _clienteRepository.Buscar(id);
           else return null; 
        } 

        public Cliente Buscar(string email)
        => _clienteRepository.Buscar(email);

        public void Deletar(int id)
        {
            if(ClienteExists(id)) _clienteRepository.Deletar(id);
        } 

        private bool CheckCliente(Cliente cliente)
        {
            ClientValidator validations = new ClientValidator(_clienteRepository);
            var validationResult = validations.Validate(cliente);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(";", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new BussinessException(errors);
            }

            return true;
        }

        private bool ClienteExists(int id) 
        {
            var cliente = _clienteRepository.Buscar(id);
            if (cliente != null) return true;
            throw new BussinessException("Cliente não Existe");
        }
    }
}
