using System.ComponentModel.DataAnnotations;

namespace Pizzaria_back.Models
{
    public class Produto : DbEntity
    {
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
        public string Imagem { get; set; } = string.Empty;
        public bool Fracionado { get; set; }

    }
}
