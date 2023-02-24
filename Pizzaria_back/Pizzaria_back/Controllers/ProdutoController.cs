using Microsoft.AspNetCore.Mvc;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

namespace Pizzaria_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoServices;

        public ProdutoController(IProdutoService produtoService)  //Construtor - Conhece a interface do ProdutoService, onde estão as verificações
        {
            _produtoServices = produtoService;
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(_produtoServices.Buscar());
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Produto produto)
        {
            _produtoServices.Inserir(produto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Produto produto)
        {
            _produtoServices.Atualizar(produto);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _produtoServices.Deletar(id);
            return Ok();
        }
    }
}
