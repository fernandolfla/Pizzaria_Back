using Bogus;
using Moq;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Service;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Pizzaria.Test.Services
{
    public class CategoriaServiceUT
    {
        private Faker faker;
        private Mock<ICategoriaRepository> categoriaRepository;
        private CategoriaService service;

        public CategoriaServiceUT()
        {
            faker = new Faker();
            categoriaRepository = new Mock<ICategoriaRepository>();
            service = new CategoriaService(categoriaRepository.Object);
        }

        [Fact]
        public void CategoriaService_Inserir()
        {
            //Arrange
            var categoria = new Categoria
            {
                Id = 0,
                Ativo = true,
                Nome = faker.Lorem.Letter(3),
                Pizza = false,
            };

            //Act
            service.Inserir(categoria);

            //Assert
            categoriaRepository.Verify(x => x.Inserir(categoria));
        }

        [Fact]
        public void CategoriaService_Atualizar()
        {
            //Arrange
            var categoria = new Categoria
            {
                Id = faker.Random.Int(1, 99999999),
                Ativo = true,
                Nome = faker.Lorem.Letter(3),
                Pizza = false,
            };

            //Act

            categoriaRepository.Setup(x => x.Buscar(categoria.Id)).Returns(categoria);

            service.Atualizar(categoria);

            //Assert
            categoriaRepository.Verify(x => x.Atualizar(categoria));
        }

        [Fact]
        public void CategoriaService_BuscarTudo()
        {
            //Arrange
            var categorias = new List<Categoria>();
            for (int i = 0; i < 10; i++)
            {
                categorias.Add(new Categoria
                {
                    Id = faker.Random.Int(),
                    Ativo = true,
                    Nome = faker.Lorem.Letter(10),
                    Pizza = false
                });
            }

            //Acr
            categoriaRepository.Setup(x => x.BuscarTudo()).Returns(categorias);

            //Assert
            Assert.NotEmpty(categorias);
        }
    }
}