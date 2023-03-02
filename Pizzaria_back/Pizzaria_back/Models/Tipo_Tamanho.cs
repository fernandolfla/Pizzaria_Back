namespace Pizzaria_back.Models
{
    public class Tipo_Tamanho : DbEntity
    {
        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }
        public int TamanhoId { get; set; }
        public virtual Tamanho Tamanho { get; set; }
        public double Preco { get; set; }
    }
}
