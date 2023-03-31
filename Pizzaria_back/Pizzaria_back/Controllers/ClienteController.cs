using Microsoft.AspNetCore.Mvc;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;

namespace Pizzaria_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteServices;

        public ClienteController(IClienteService clienteServices)
        {
            _clienteServices = clienteServices;
        }

        //[HttpGet]
        //public IActionResult Buscar()
        //    => Ok(_clienteServices.Buscar());

        //[HttpPost]
        //public IActionResult Inserir([FromBody] Cliente cliente)
        //{
        //    _clienteServices.Inserir(cliente);
        //    return Ok();
        //}

        //[HttpPut]
        //public IActionResult Atualizar([FromBody] Cliente cliente)
        //{
        //    _clienteServices.Atualizar(cliente);
        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Deletar(int id)
        //{
        //    _clienteServices.Deletar(id);
        //    return Ok();
        //}

    }
}
