using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
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
        //private Faker fake;

        //private Mock<IUsuarioRepository> usuarioRepository;
        //private Mock<ITokenService> tokenService;
        //private Mock<IConfiguration> configuration;

        //private IUsuarioService usuarioService;

        //public UsuarioServiceUT()
        //{
        //    fake = new Faker();

        //    usuarioRepository = new Mock<IUsuarioRepository>();
        //    tokenService = new Mock<ITokenService>();   
        //    configuration = new Mock<IConfiguration>();

        //    configuration.Setup(x => x.GetSection(It.IsAny<string>()).GetValue<string>(It.IsAny<string>()))
        //                 .Returns(fake.Random.String2(25));         

        //    usuarioService = new UsuarioService(usuarioRepository.Object, tokenService.Object, configuration.Object);
        //}

        //[Fact]
        //public void UsuarioService_Logar_Sucesso()
        //{
        //    //Arrange
        //    var email = fake.Internet.Email();
        //    var senha = "Senha123!";
        //    var usuario = new Usuario
        //    {
        //        Ativo = true,
        //        Email = email,
        //        Senha = senha,
        //        Papel = fake.Random.Enum<PapelEnum>(),
        //        Id = fake.Random.Int()
        //    };
        //    var tokenEsperado = fake.Random.String2(300);

        //    usuarioRepository.Setup(x => x.Buscar())
        //                     .Returns(new List<Usuario> { usuario }.AsQueryable());

        //    tokenService.Setup(x => x.GenerateToken(usuario)).Returns(tokenEsperado);

        //    //Act
        //    var token = usuarioService.Logar(email, senha);

        //    //Assert
        //    token.Should().Equals(tokenEsperado);
        //}
    }
}
