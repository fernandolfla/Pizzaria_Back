namespace Pizzaria_back.Models
{
    public class Categoria : DbEntity
    {
        public Categoria() 
        {
            Pizza = false;
        }
        public string Nome { get; set; }
        public bool Pizza { get; set; }
    }
}
