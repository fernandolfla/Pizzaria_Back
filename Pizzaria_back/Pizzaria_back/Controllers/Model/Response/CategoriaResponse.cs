using Pizzaria_back.Models;

namespace Pizzaria_back.Controllers.Model.Response
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Pizza { get; set; }
        public bool Ativo { get; set; }

        public static implicit operator CategoriaResponse(Categoria objeto)
        {
            return new CategoriaResponse
            {
                Id = objeto.Id,
                Nome = objeto.Nome,
                Pizza = objeto.Pizza,
                Ativo = objeto.Ativo
            };
        }
    }
}
