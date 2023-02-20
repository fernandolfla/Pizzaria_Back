using FluentValidation;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Models;
using Pizzaria_back.Repository;
using Pizzaria_back.Service;
using Pizzaria_back.Validators;

namespace Pizzaria_back
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            /*
            // **** Injeção de dependência ****
            //Services AddSingleton sempre que o controller for instanciado, meu objeto será instanciado até a finalização da aplicação para TODOS os usuários da aplicação
            //Services AddScoped objeto instanciado até a finalização do método 
            //Services AddAddTransient  toda vez que o controlador é instanciado, será gerado uma nova instância do objeto em dependencia
            */
            // Registro das dependências
            //Injeção de dependencias para acesso ao repositório

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITipoRepository, TipoRepository>();
            services.AddScoped<ITamanhoRepository, TamanhoRepository>();
            services.AddScoped<ISaborRepository, SaborRepository>();
            services.AddScoped<ITipo_TamanhoRepository, Tipo_TamanhoRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));



            //Injeção de dependências para acesso aos serviços / regras de negócio
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITipoService, TipoService>();
            services.AddScoped<ITamanhoService, TamanhoService>();
            services.AddScoped<ISaborService, SaborService>();
            services.AddScoped<ITipo_TamanhoService, Tipo_TamanhoService>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
        }
    }
}
