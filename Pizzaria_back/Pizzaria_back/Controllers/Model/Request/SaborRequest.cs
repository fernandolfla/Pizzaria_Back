using Pizzaria_back.Models;

namespace Pizzaria_back.Controllers.Model.Request
{
    public class SaborRequest
    {
        public string Nome { get; set; }

        public static implicit operator Sabor(SaborRequest objeto) 
        {
            return new Sabor
            {
                Nome = objeto.Nome
            };
        }
    }
}
