using Microsoft.AspNetCore.Mvc;
using Pizzaria_back.Controllers.Model.Request;
using Pizzaria_back.Controllers.Model.Response;
using Pizzaria_back.Models;

namespace Pizzaria_back.Controllers
{
    public partial class TipoController : ControllerBase
    {

        [HttpPost("{id}/Sabor")]
        public IActionResult InserirSabor(int id, [FromBody] SaborRequest objeto)
        {
            _saborService.Inserir(objeto);
            return Ok();
        }

        [HttpPut("{id}/Sabor")]
        public IActionResult AtualizarSabor(int id, [FromBody] Sabor objeto)
        {
            _saborService.Atualizar(objeto);
            return Ok();
        }
        [HttpGet("{id}/Sabor")]
        public IActionResult BuscarSabor(int id)
        {
            return Ok(_saborService.Buscar().Select(x => (SaborResponse)x));
        }

        [HttpDelete("{id}/Sabor/{idSabor}")]
        public IActionResult DeletarSabor(int idSabor)
        {
            _saborService.Deletar(idSabor);
            return Ok();
        }
    }
}
