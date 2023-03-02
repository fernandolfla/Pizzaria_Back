using Pizzaria_back.Models.Enum;

namespace Pizzaria_back.Models
{
    public class Usuario: DbEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public PapelEnum Papel { get; set; }
    }
}
