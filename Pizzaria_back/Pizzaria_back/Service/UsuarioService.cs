using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Validators;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria_back.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public string Logar(string email, string senha)
        {
            Validar(new Usuario { Email = email, Senha = senha });

            var usuario = _usuarioRepository.Buscar(email, senha);
            if (usuario == null)
                throw new UnauthorizedAccessException("Email ou senha invalidos");

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }

        public void Criar(Usuario user)
        {
            Validar(user);

            _usuarioRepository.Criar(user);
        }

        private void Validar(Usuario usuario)
        {
            var validator = new UsuarioValidator();
            var validationResult = validator.Validate(usuario);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(";", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new BussinessException(errors);
            }
        }
    }
}
