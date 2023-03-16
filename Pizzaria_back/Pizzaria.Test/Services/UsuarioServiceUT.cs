using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Moq;
using Pizzaria_back.Helpers;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Models.Enum;
using Pizzaria_back.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pizzaria.Test.Services
{
    public class UsuarioServiceUT
    {
        private Faker fake;

        private Mock<IUsuarioRepository> usuarioRepository;
        private Mock<ITokenService> tokenService;
        private IConfiguration configuration;

        private IUsuarioService usuarioService;

        public UsuarioServiceUT()
        {
            fake = new Faker();
            var inMemorySettings = new Dictionary<string, string> {{ "Crypto:Secret", "pizzaria123456789!@#" } };

            usuarioRepository = new Mock<IUsuarioRepository>();
            tokenService = new Mock<ITokenService>();

            configuration = new ConfigurationBuilder()
                                .AddInMemoryCollection(inMemorySettings)
                                .Build();

            usuarioService = new UsuarioService(usuarioRepository.Object, tokenService.Object, configuration);
        }

        [Fact]
        public void UsuarioService_Logar_Sucesso()
        {
            //Arrange
            var email = fake.Internet.Email();
            var senha = "Senha123!";
            var usuario = new Usuario
            {
                Ativo = true,
                Email = email,
                Senha = CriptografiaHelper.CriptografarAes(senha, configuration.GetValue<string>("Crypto:Secret")) ?? string.Empty,
                Papel = fake.Random.Enum<PapelEnum>(),
                Id = fake.Random.Int()
            };
            var tokenEsperado = fake.Random.String2(300);

            usuarioRepository.Setup(x => x.Buscar())
                             .Returns(new List<Usuario> { usuario }.AsQueryable());

            tokenService.Setup(x => x.GenerateToken(usuario)).Returns(tokenEsperado);

            //Act
            var token = usuarioService.Logar(email, senha);

            //Assert
            token.Should().BeSameAs(tokenEsperado);
        }

        [Fact]
        public void UsuarioService_Logar_Invalido()
        {
            //Arrange
            var email = fake.Internet.Email();
            var senha = "Senha1234!";
            var usuario = new Usuario
            {
                Ativo = true,
                Email = email,
                Senha = CriptografiaHelper.CriptografarAes("Senha123!", configuration.GetValue<string>("Crypto:Secret")) ?? string.Empty,
                Papel = fake.Random.Enum<PapelEnum>(),
                Id = fake.Random.Int()
            };
            var tokenEsperado = fake.Random.String2(300);

            usuarioRepository.Setup(x => x.Buscar())
                             .Returns(new List<Usuario> { usuario }.AsQueryable());

            tokenService.Setup(x => x.GenerateToken(usuario)).Returns(tokenEsperado);

            //Act
            Assert.Throws<UnauthorizedAccessException>(() => usuarioService.Logar(email, senha));
        }

        [Fact]
        public void UsuarioService_Criar_ErroEmailDuplicado()
        {
            //Arrange
            var email = fake.Internet.Email();
            var senha = "Senha123!";
            var usuario = new Usuario
            {
                Ativo = true,
                Email = email,
                Senha = senha,
                Papel = fake.Random.Enum<PapelEnum>(),
                Id = fake.Random.Int()
            };

            usuarioRepository.Setup(x => x.Buscar())
                             .Returns(new List<Usuario> { usuario }.AsQueryable());

            //Act
            Assert.Throws<BussinessException>(() => usuarioService.Criar(usuario));
        }

        [Fact]
        public void UsuarioService_Criar_Sucesso()
        {
            //Arrange
            var email = fake.Internet.Email();
            var senha = "Senha123!";
            var usuario = new Usuario
            {
                Ativo = true,
                Email = email,
                Senha = senha,
                Papel = fake.Random.Enum<PapelEnum>(),
                Id = fake.Random.Int()
            };

            //Act
            usuarioService.Criar(usuario);

            //Assert
            usuarioRepository.Verify(x => x.Criar(usuario));
        }
    }
}
