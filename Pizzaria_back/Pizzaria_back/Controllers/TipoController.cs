using Microsoft.AspNetCore.Mvc;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

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
        public IActionResult Inserir([FromBody] Tipo tipo)
        {
            _service.Inserir(tipo);
            return Ok();
        }


        [HttpGet]
        public IActionResult Buscar() 
        {
            return Ok(_service.Buscar());
        }
    }
}
