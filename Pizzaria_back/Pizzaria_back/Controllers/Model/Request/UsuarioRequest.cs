using Pizzaria_back.Models;
using Pizzaria_back.Models.Enum;

namespace Pizzaria_back.Controllers.Model.Request
{
    public class UsuarioRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public PapelEnum Papel { get; set; }


        public static implicit operator Usuario(UsuarioRequest usuarioRequest)
        {
            return new Usuario
            {
                Email = usuarioRequest.Email,
                Senha = usuarioRequest.Senha,
                Papel = usuarioRequest.Papel
            };
        }
    }
}
