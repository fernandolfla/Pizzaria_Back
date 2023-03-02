namespace Pizzaria_back.Models
{
    public class Tipo : DbEntity
    {
        public string Nome { get; set; } = string.Empty;
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
