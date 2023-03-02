using Pizzaria_back.Models;

namespace Pizzaria_back.Interfaces.Service
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);

    }
}
