using Microsoft.EntityFrameworkCore;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Repository;
using Pizzaria_back.Service;

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
            //services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
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
            //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        private static void AdicionarMySQL(this IServiceCollection services, IConfiguration configuration)
        {
            string? mySqlConnection = configuration.GetConnectionString("DB_MySQL");  //Endereço do banco de dados
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.Parse("5.5.20")));
        }
    }
}
