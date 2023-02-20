namespace Pizzaria_back.Models
{
    public class Tipo_Tamanho : DbEntity
    {
        public int TipoId { get; set; }
        public Tipo Tipo;
        public int TamanhoId { get; set; }
        public Tamanho Tamanho;
        public double Preco { get; set; }
    }
}
