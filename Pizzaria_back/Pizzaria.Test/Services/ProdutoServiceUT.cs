using Moq;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Models;
using Pizzaria_back.Service;
using Xunit;

namespace Pizzaria.Test.Services
{
    public class ProdutoServiceUT
    {
        [Fact]
        public void Produto_Inserir_ComSucesso()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);

            Produto produto = new Produto
            {
                Id = 1,
                Nome = "Coca cola",
                Preco = 13,
                Ativo = true
            };

            //Act
            _produtoService.Inserir(produto);

            //Assert
            produtoRepositoryMock.Verify(x => x.Inserir(produto));
        }

        [Fact]
        public void Produto_Inserir_Duplicado_DeveFalhar()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
            produtoRepositoryMock.Setup(x => x.Buscar(It.IsAny<int>()))
                                 .Returns(new Produto());

            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);
            Produto produto = new Produto
            {
                Id = 1,
                Nome = "Coca cola",
                Preco = 13,
                Ativo = true
            };

            //ACT

            //Assert
            Assert.Throws<BussinessException>(() => _produtoService.Inserir(produto));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-25)]
        public void Produto_Inserir_SemPreco_DeveFalha(int preco)
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();

            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);
            Produto produto = new Produto
            {
                Id = 1,
                Nome = "Coca cola",
                Preco = preco,
                Ativo = true
            };

            //ACT

            //Assert
            Assert.Throws<BussinessException>(() => _produtoService.Inserir(produto));
        }

        [Fact]
        public void Produto_Inserir_SemNome_DeveFalhar()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();

            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);
            Produto produto = new Produto
            {
                Id = 1,
                Nome = string.Empty,
                Preco = 13,
                Ativo = true
            };

            //ACT

            //Assert
            Assert.Throws<BussinessException>(() => _produtoService.Inserir(produto));
        }

        [Fact]
        public void Produto_Buscar_ComSucesso()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
            produtoRepositoryMock.Setup(x => x.Buscar())
                                 .Returns(new List<Produto>()
                                 {
                                     new Produto { Id = 1,},
                                     new Produto { Id = 2,},
                                 });

            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);

            //Act
            var produtos = _produtoService.Buscar();

            //Assert
            Assert.NotEmpty(produtos);
        }

        [Fact]
        public void Produto_BuscarPorId_ComSucesso()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
            produtoRepositoryMock.Setup(x => x.Buscar(It.IsAny<int>()))
                                 .Returns(new Produto { Id = 1, Ativo = true });

            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);

            //Act
            var produto = _produtoService.Buscar(1);

            //Assert
            Assert.NotNull(produto);
            Assert.True(produto.Ativo);
        }

        [Fact]
        public void Produto_Deletar_ComSucesso()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);

            //Act
            _produtoService.Deletar(1);

            //Assert
            produtoRepositoryMock.Verify(x => x.Deletar(It.IsAny<int>()));
        }

        [Fact]
        public void Produto_Atualizar_ComSucesso()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);

            Produto produto = new Produto
            {
                Id = 1,
                Nome = "Coca cola",
                Preco = 13,
                Ativo = true
            };

            //Act
            _produtoService.Atualizar(produto);

            //Assert
            produtoRepositoryMock.Verify(x => x.Atualizar(produto));
        }

        [Fact]
        public void Produto_Atualizar_SemId_DeveFalhar()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);
            Produto produto = new Produto
            {
                Id = 0,
                Nome = "Coca cola",
                Preco = 13,
                Ativo = true
            };

            //ACT

            //Assert
            Assert.Throws<BussinessException>(() => _produtoService.Atualizar(produto));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-25)]
        public void Produto_Atualizar_SemPreco_DeveFalha(int preco)
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();

            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);
            Produto produto = new Produto
            {
                Id = 1,
                Nome = "Coca cola",
                Preco = preco,
                Ativo = true
            };

            //ACT

            //Assert
            Assert.Throws<BussinessException>(() => _produtoService.Atualizar(produto));
        }

        [Fact]
        public void Produto_Atualizar_SemNome_DeveFalhar()
        {
            //Arange
            Mock<IProdutoRepository> produtoRepositoryMock = new Mock<IProdutoRepository>();
            ProdutoService _produtoService = new ProdutoService(produtoRepositoryMock.Object);
            Produto produto = new Produto
            {
                Id = 1,
                Nome = string.Empty,
                Preco = 13,
                Ativo = true
            };

            //ACT

            //Assert
            Assert.Throws<BussinessException>(() => _produtoService.Atualizar(produto));
        }

    }
}