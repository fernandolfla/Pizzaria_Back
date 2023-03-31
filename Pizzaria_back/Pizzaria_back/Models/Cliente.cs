namespace Pizzaria_back.Models
{
    public class Cliente : DbEntity
    {
        public string Nome { get; set; } = string.Empty;
        public DateOnly Nascimento { get; set; }
        public string CPF { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set;}
    }
}
