using Pizzaria_back.Models;

namespace Pizzaria_back.Controllers.Model.Response
{
    public class SaborResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static implicit operator SaborResponse(Sabor sabor)
        {
            return new SaborResponse
            {
                Id = sabor.Id,
                Nome = sabor.Nome,
            };
        }
    }
}
