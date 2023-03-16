using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzaria_back.Controllers.Model.Request;
using Pizzaria_back.Interfaces.Service;

namespace Pizzaria_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("[Action]")]
        [AllowAnonymous]
        public IActionResult Logar([FromBody] LoginRequest loginRequest)
        {
            var token = _usuarioService.Logar(loginRequest.Email, loginRequest.Senha);

            return Ok(new
            {
                Token = token,
                Email = loginRequest.Email,
            });
        }

        [HttpPost("[Action]")]
        [Authorize(Policy = "admin")]
        public IActionResult Criar([FromBody] UsuarioRequest usuarioRequest)
        {
            _usuarioService.Criar(usuarioRequest);
            return Ok();
        }

    }
}
