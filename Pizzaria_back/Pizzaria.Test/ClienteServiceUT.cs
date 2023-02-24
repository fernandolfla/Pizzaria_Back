using Moq;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pizzaria.Test
{
    public class ClienteServiceUT
    {
        private ClienteService _clienteService;
        private Mock<IClienteRepository> clienteRepositoryMock;
        public ClienteServiceUT() {
            this.clienteRepositoryMock = new Mock<IClienteRepository>();
            this._clienteService= new ClienteService(clienteRepositoryMock.Object);
        }

        [Fact]
        public void Cliente_Inserir_ComSucesso()
        {
            //Arange

            Cliente cliente = new Cliente
            {
                Ativo = true,
                Nome= "Fernandinho",
                Telefone= "41988165786",
                Email = "fer@fer.com",

            };

            //Act
            _clienteService.Inserir(cliente);

            //Assert

            clienteRepositoryMock.Verify(x => x.Inserir(cliente));
        }

        [Fact]
        public void Cliente_Inserir_Email_Duplicado()
        {
            var email = "fer@fer.com";
            var cliente = new Cliente
            {
                Ativo = true,
                Nome= "Fernandinho",
                Telefone= "41988165786",
                Email = email,
            };
            var clienteExists = new Cliente {
                Id = 1,
                Ativo = true,
                Nome= "Fernandinho",
                Telefone= "41988165786",
                Email = email,
            };

            clienteRepositoryMock.Setup(x => x.Buscar(email)).Returns(clienteExists);

            Assert.Throws<BussinessException>(() => _clienteService.Inserir(cliente));
        }

        [Fact]
        public void Listar_Cliente()
        {
            clienteRepositoryMock.Setup(x => x.Buscar()).Returns(
                new List<Cliente>(){
                    new Cliente
                        {
                            Id = 1,
                            Ativo = true,
                            Nome= "Fernandinho",
                            Telefone= "41988165786",
                            Email = "fer@fer.com",
                        },
                      new Cliente
                        {
                            Id = 2,
                            Ativo = true,
                            Nome= "Vitor",
                            Telefone= "41988165786",
                            Email = "vitor@fer.com",
                        }
                }
            );

            Assert.NotEmpty(_clienteService.Buscar());
        }

        [Fact]
        public void Buscar_Id()
        {
            var id = 1;
            clienteRepositoryMock.Setup(x => x.Buscar(id)).Returns(
                 new Cliente
                        {
                            Id = 1,
                            Ativo = true,
                            Nome= "Fernandinho",
                            Telefone= "41988165786",
                            Email = "fer@fer.com",
                        }
            );

            Assert.NotNull(_clienteService.Buscar(id)); 
        }

        [Fact]
        public void Erro_Buscar_Id()
        {
            Assert.Throws<BussinessException>(() => _clienteService.Buscar(1));
        }

        [Fact]
        public void Atualizar_Inexistente()
        {
            var cliente = new Cliente
            {
                Id = 1,
                Ativo = true,
                Nome= "Fernandinho",
                Telefone= "41988165786",
                Email = "fer@fer.com",
            };
            Assert.Throws<BussinessException>(() => _clienteService.Atualizar(cliente));
        }

        [Fact]
        public void Atualizar_Cliente()
        {
            var cliente = new Cliente
            {
                Id = 1,
                Ativo = true,
                Nome= "Fernandinho",
                Telefone= "41988165786",
                Email = "fer@fer.com",
            };

            clienteRepositoryMock.Setup(x => x.Buscar(cliente.Id)).Returns(cliente);

            _clienteService.Atualizar(cliente);

            clienteRepositoryMock.Verify(x => x.Atualizar(cliente));
        }

        [Fact]
        public void Deletar_Cliente()
        {
            var cliente = new Cliente
            {
                Id = 1,
                Ativo = true,
                Nome= "Fernandinho",
                Telefone= "41988165786",
                Email = "fer@fer.com",
            };

            clienteRepositoryMock.Setup(x => x.Buscar(cliente.Id)).Returns(cliente);

            _clienteService.Deletar(cliente.Id);

            clienteRepositoryMock.Verify(x => x.Deletar(cliente.Id));

        }

        [Fact]
        public void Deletar_Sem_Sucesso()
        {
            Assert.Throws<BussinessException>(() => _clienteService.Deletar(2));
        }
    }
}
