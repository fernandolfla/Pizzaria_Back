using Microsoft.AspNetCore.Mvc;
using Pizzaria_back.Controllers.Model.Request;
using Pizzaria_back.Controllers.Model.Response;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Service;
using System;

namespace Pizzaria_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet("Buscar")]
        public IActionResult Buscar()
            => Ok(_service.Buscar().Select(x => (CategoriaResponse)x));

        [HttpGet("BuscarTudo")]
        public IActionResult BuscarTudo()
           => Ok(_service.BuscarTudo().Select(x => (CategoriaResponse)x));



        [HttpPost]
        public IActionResult Inserir([FromBody] CategoriaRequest objeto)
        {
            _service.Inserir(objeto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] CategoriaRequest objeto)
        {
            _service.Atualizar(objeto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _service.Deletar(id);
            return Ok();
        }
    }
}
