﻿using Pizzaria_back.Helpers;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Validators;

namespace Pizzaria_back.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public string Secret { get => _configuration.GetSection("Crypto").GetValue<string>("Secret"); }

        public UsuarioService(IUsuarioRepository usuarioRepository, ITokenService tokenService, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public string Logar(string email, string senha)
        {
            var usuario = new Usuario { Email = email, Senha = senha };
            Validar(usuario);

            var usuarioBD = _usuarioRepository.Buscar(email, senha);
            if (usuarioBD == null)
                throw new UnauthorizedAccessException("Email ou senha invalidos");

            return _tokenService.GenerateToken(usuarioBD);
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
            if (validationResult.IsValid)
            {
                usuario.Senha = CriptografiaHelper.CriptografarAes(usuario.Senha, Secret);
                if (usuario.Senha is null)
                    throw new BussinessException("Não conseguimos salvar sua senha.");
            }
            else
            {
                var errors = string.Join(";", validationResult.Errors.Select(x => x.ErrorMessage));
                throw new BussinessException(errors);
            }
        }
    }
}
