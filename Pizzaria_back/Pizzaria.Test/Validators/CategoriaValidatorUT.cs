using Bogus;
using FluentAssertions;
using Moq;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Validators;
using Xunit;

namespace Pizzaria.Test.Validators
{
    public class CategoriaValidatorUT
    {
        private Faker faker;
        private Mock<ICategoriaRepository> categoriasRepository;
        private CategoriaValidator validator;

        public CategoriaValidatorUT()
        {
            faker = new Faker();
            categoriasRepository = new Mock<ICategoriaRepository>();
            validator = new CategoriaValidator(categoriasRepository.Object);
        }


        [Fact]
        public void CategoriasValidator_Validar_Id_Negativo_Updates()
        {
            //Arrange
            var Categoria = new Categoria
            {
                Id = faker.Random.Int(-99999999, -1),
                Ativo = true,
                Nome = "Name",
                Pizza = false,
            };

            //Act
            var validadorCategoria = validator.Validate(Categoria);

            //Assert
            validadorCategoria.Errors.Should().NotBeNullOrEmpty();
            validadorCategoria.Errors.Should().HaveCount(1);
            validadorCategoria.Errors.Should().Contain(x => x.ErrorMessage == "categoria invalida");
        }

        [Theory]
        [InlineData("")]//Nome sem preencher
        [InlineData("a")]//Nome com menos de 3 caracteres
        [InlineData("ab")]//Nome com menos de 3 caracteres
        public void CategoriasValidator_Validar_Nome(string nome)
        {
            //Arrange
            var Categoria = new Categoria
            {
                Id = faker.Random.Int(0, 99999999),
                Ativo = true,
                Nome = nome,
                Pizza = false,
            };

            //Act
            var validadorCategoria = validator.Validate(Categoria);

            //Assert
            validadorCategoria.Errors.Should().NotBeNullOrEmpty();
        }
    }
}
