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
        [Fact]
        public void Cliente_Inserir_ComSucesso()
        {
            //Arange
            Mock<IClienteRepository> clienteRepositoryMock = new Mock<IClienteRepository>();
            ClienteService _clienteService = new ClienteService(clienteRepositoryMock.Object);

            Cliente cliente = new Cliente
            {
                Id = 1,
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
        public void Cliente_Inserir_Duplicado_DeveFalhar()
        {
            //Arrange
            Mock<IClienteRepository> clienteRepositoryMock = new Mock<IClienteRepository>();
            clienteRepositoryMock.Setup(x => x.Buscar(It.IsAny<int>())).Returns(new Cliente());

            ClienteService _clienteService = new ClienteService(clienteRepositoryMock.Object);
            Cliente cliente = new Cliente
            {
                Id = 1,
                Ativo = true,
                Nome = "Fernandinho", 
                Telefone = "41988165786",
                Email = "fer@fer.com",  

            };

            //Act

            //Assert
            Assert.Throws<BussinessException>(() => _clienteService.Inserir(cliente));

            
        }


    }
}
