namespace Pizzaria_back.Models
{
    public class Tamanho : DbEntity
    {
        public string Nome { get; set; }
        public int QtdSabor { get; set; }
        public int QtdFatias { get; set; }

    }
}
