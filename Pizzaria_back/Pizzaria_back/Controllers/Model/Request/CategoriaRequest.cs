using Pizzaria_back.Models;

namespace Pizzaria_back.Controllers.Model.Request
{
    public class CategoriaRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static implicit operator Categoria(CategoriaRequest objeto)
        {
            return new Categoria
            {
                Id = objeto.Id,
                Nome = objeto.Nome
            };
        }
    }
}
