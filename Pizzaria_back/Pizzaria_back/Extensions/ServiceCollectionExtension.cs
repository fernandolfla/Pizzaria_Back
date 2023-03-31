using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models.Enum;
using Pizzaria_back.Repository;
using Pizzaria_back.Service;
using System.Text;

namespace Pizzaria_back.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// **** Injeção de dependência ****
        ///Services AddSingleton sempre que o controller for instanciado, meu objeto será instanciado até a finalização da aplicação para TODOS os usuários da aplicação
        ///Services AddScoped objeto instanciado até a finalização do método 
        ///Services AddAddTransient  toda vez que o controlador é instanciado, será gerado uma nova instância do objeto em dependencia
        /// </summary>
        /// <param name="services"></param>
        public static void AdicionarDependenciasPizzaria(this IServiceCollection services, IConfiguration configuration)
        {
            services.AdicionarMySQL(configuration);
            services.AdicionarDependenciasRepositorio();
            services.AdicionarDependenciasServicos();
            services.AdicionarAutenticacao(configuration);
            services.AdicionarAutorizacao();
        }

        /// <summary>
        /// Injeção de dependências para acesso aos serviços / regras de negócio
        /// </summary>
        /// <param name="services"></param>
        private static void AdicionarDependenciasServicos(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITipoService, TipoService>();
            services.AddScoped<ITamanhoService, TamanhoService>();
            services.AddScoped<ISaborService, SaborService>();
            services.AddScoped<ITipo_TamanhoService, Tipo_TamanhoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddSingleton<ITokenService, TokenService>();
        }

        /// <summary>
        /// Injeção de dependencias para acesso ao repositório
        /// </summary>
        /// <param name="services"></param>
        private static void AdicionarDependenciasRepositorio(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITipoRepository, TipoRepository>();
            services.AddScoped<ITamanhoRepository, TamanhoRepository>();
            services.AddScoped<ISaborRepository, SaborRepository>();
            services.AddScoped<ITipo_TamanhoRepository, Tipo_TamanhoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        private static void AdicionarMySQL(this IServiceCollection services, IConfiguration configuration)
        {
            string? mySqlConnection = configuration.GetConnectionString("DB_MySQL");  //Endereço do banco de dados
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.Parse("5.5.20")));
        }

        private static void AdicionarAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            var secret = configuration.GetSection("Authorization").GetValue<string>("Secret");

            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        private static void AdicionarAutorizacao(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("user", policy => policy.RequireClaim("papel", PapelEnum.Usuario.ToString()));
                options.AddPolicy("admin", policy => policy.RequireClaim("papel", PapelEnum.Administrador.ToString()));
            });
        }

    }
}
