using Microsoft.AspNetCore.Mvc;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Service;

namespace Pizzaria_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ITipoService _service;

        public TipoController(ITipoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Tipo objeto)
        {
            _service.Inserir(objeto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] Tipo objeto)
        {
            _service.Atualizar(objeto);
            return Ok();
        }
        [HttpGet]
        public IActionResult Buscar()       
          => Ok(_service.Buscar());       

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
            => Ok(_service.Buscar(id));

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _service.Deletar(id);
            return Ok();
        }

    }
}
