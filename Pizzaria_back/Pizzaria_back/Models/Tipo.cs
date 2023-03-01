using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria_back.Models
{
    public class Tipo : DbEntity
    {
        public string Nome { get; set; } = string.Empty;
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
