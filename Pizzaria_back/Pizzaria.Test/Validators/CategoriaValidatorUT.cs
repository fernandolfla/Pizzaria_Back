using Bogus;
using FluentAssertions;
using Moq;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Nome = faker.Name.ToString(),
                Pizza = false,
            };

            //Act
            var validadorCategoria = validator.Validate(Categoria);

            //Assert
            validadorCategoria.Errors.Should().NotBeNullOrEmpty();

            //validadorUsuario.Errors.Should().NotBeNullOrEmpty();
            //validadorUsuario.Errors.Should().HaveCount(1);
            //validadorUsuario.Errors.Should().Contain(x => x.ErrorMessage == "Email invalido");


        }


    }
}
