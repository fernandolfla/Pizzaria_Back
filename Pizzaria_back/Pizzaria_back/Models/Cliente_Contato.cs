namespace Pizzaria_back.Models
{
    public class Cliente_Contato : DbEntity
    {
        public string Label { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int ClienteId { get; set;}
        public virtual Cliente Cliente { get; set; }
    }
}
