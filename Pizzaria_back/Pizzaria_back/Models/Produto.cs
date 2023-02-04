namespace Pizzaria_back.Models
{
    public class Produto : DbEntity
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Imagem { get; set; }
    }
}
