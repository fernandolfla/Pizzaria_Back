namespace Pizzaria_back.Models
{
    public class Sabor: DbEntity
    {
        public string Nome { get; set; }
        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }
    }
}
