namespace Pizzaria_back.Models
{
    public class Cliente_Endereco : DbEntity
    {
        public string Label { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string NumRua { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set;}
    }
}
