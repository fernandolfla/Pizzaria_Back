using Pizzaria_back.Models;

namespace Pizzaria_back.Controllers.Model.Response
{
    public class SaborResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static implicit operator SaborResponse(Sabor objeto)
        {
            return new SaborResponse
            {
                Id = objeto.Id,
                Nome = objeto.Nome,
            };
        }
    }
}
