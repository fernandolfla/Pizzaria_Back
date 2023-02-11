using System.Diagnostics.CodeAnalysis;

namespace Pizzaria_back.Models
{
    [ExcludeFromCodeCoverage]
    public class BussinessException: Exception
    {
        public BussinessException(string mensagem) : base(mensagem)
        {
            
        }
    }
}
