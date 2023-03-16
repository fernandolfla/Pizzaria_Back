using Bogus;
using Moq;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Models.Enum;
using Pizzaria_back.Validators;
using Xunit;
using FluentValidation;
using FluentAssertions;
using Pizzaria_back.Resources;

namespace Pizzaria.Test.Validators
{
    public class UsuarioValidatorUT
    {
        private Faker faker;

        private Mock<IUsuarioRepository> usuarioRepositoryMock;
        private bool eLogin = false;

        private UsuarioValidator validator;

        public UsuarioValidatorUT()
        {
            usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            faker = new Faker();

            validator = new UsuarioValidator(usuarioRepositoryMock.Object, eLogin);
        }

        [Fact]
        public void UsuarioValidator_Validar_EmailVazio()
        {
            //Arrange
            var usuario = new Usuario
            {
                Email = string.Empty,
                Ativo = true,
                Id = faker.Random.Int(1, int.MaxValue),
                Papel = faker.Random.Enum<PapelEnum>(),
                Senha = "Senha123!"
            };

            //Act
            var validadorUsuario = validator.Validate(usuario);

            //Assert
            //Assert.NotEmpty(validationResult.Errors); -> padrão do xunit
            validadorUsuario.Errors.Should().NotBeNullOrEmpty();
            validadorUsuario.Errors.Should().HaveCount(1);
            validadorUsuario.Errors.Should().Contain(x => x.ErrorMessage == Resource.usario_emailInvalido);
        }

        [Fact]
        public void UsuarioValidator_Validar_EmailIncorreto()
        {
            //Arrange
            var usuario = new Usuario
            {
                Email = "fagner.santos",
                Ativo = true,
                Id = faker.Random.Int(1, int.MaxValue),
                Papel = faker.Random.Enum<PapelEnum>(),
                Senha = "Senha123!"
            };

            //Act
            var validadorUsuario = validator.Validate(usuario);

            //Assert
            //Assert.NotEmpty(validationResult.Errors); -> padrão do xunit
            validadorUsuario.Errors.Should().NotBeNullOrEmpty();
            validadorUsuario.Errors.Should().HaveCount(1);
            validadorUsuario.Errors.Should().Contain(x => x.ErrorMessage == Resource.usario_emailInvalido);
        }

        [Fact]
        public void UsuarioValidator_Validar_UsuarioCorreto()
        {
            //Arrange
            var usuario = new Usuario
            {
                Email = faker.Internet.Email(),
                Ativo = true,
                Id = faker.Random.Int(1, int.MaxValue),
                Papel = faker.Random.Enum<PapelEnum>(),
                Senha = "Senha123!"
            };

            //Act
            var validadorUsuario = validator.Validate(usuario);

            //Assert
            validadorUsuario.IsValid.Should().BeTrue();
        }

        [Fact]
        public void UsuarioValidator_Validar_EmailDuplicado()
        {
            //Arrange
            var usuario = new Usuario
            {
                Email = faker.Internet.Email(),
                Ativo = true,
                Id = faker.Random.Int(1, int.MaxValue),
                Papel = faker.Random.Enum<PapelEnum>(),
                Senha = "Senha123!"
            };
            usuarioRepositoryMock.Setup(x => x.Buscar())
                                 .Returns( new List<Usuario>{ usuario }.AsQueryable());

            //Act
            var validadorUsuario = validator.Validate(usuario);

            //Assert
            validadorUsuario.IsValid.Should().BeFalse();
            validadorUsuario.Errors.Should().Contain(x => x.ErrorMessage == Resource.usuario_emailduplicado);
        }

        [Theory]
        [InlineData("")]//senha não preenchida
        [InlineData("senha123!")]//preenchida sem letra maiuscula
        [InlineData("SENHA123!")]//preenchida sem letra minuscula
        [InlineData("Senha1234")]//preenchida sem caractere especial
        [InlineData("Senha123")]//preenchida com menos de 8 caracteres
        public void UsuarioValidator_Validar_SenhaIncorreta(string senha)
        {
            //Arrange
            var usuario = new Usuario
            {
                Email = faker.Internet.Email(),
                Ativo = true,
                Id = faker.Random.Int(1, int.MaxValue),
                Papel = faker.Random.Enum<PapelEnum>(),
                Senha = senha
            };

            //Act
            var validadorUsuario = validator.Validate(usuario);

            //Assert
            validadorUsuario.Errors.Should().NotBeNullOrEmpty();
            validadorUsuario.Errors.Should().HaveCount(1);
            validadorUsuario.Errors.Should().Contain(x => x.ErrorMessage == Resource.usario_senhaInvalida);
        }

    }
}
