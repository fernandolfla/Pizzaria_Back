using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzaria_back.Models
{
    public class Tipo : DbEntity
    {
        public string Nome { get; set; } = string.Empty;
        public int ProdutoId { get; set;}
        public Produto Produto { get; set;} //Quando deixo aqui ele reconhece que preciso passar um produto junto com o tipo
    }
}
