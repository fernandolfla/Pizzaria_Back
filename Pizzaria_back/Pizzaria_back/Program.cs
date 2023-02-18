using Microsoft.EntityFrameworkCore;
using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Repository;
using Pizzaria_back.Service;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
// **** Injeção de dependência ****
//Services AddSingleton sempre que o controller for instanciado, meu objeto será instanciado até a finalização da aplicação para TODOS os usuários da aplicação
//Services AddScoped objeto instanciado até a finalização do método 
//Services AddAddTransient  toda vez que o controlador é instanciado, será gerado uma nova instância do objeto em dependencia
*/
//Injeção de dependencias para acesso ao repositório
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITipoRepository, TipoRepository>();
builder.Services.AddScoped<ITamanhoRepository, TamanhoRepository>();
builder.Services.AddScoped<ISaborRepository, SaborRepository>();
builder.Services.AddScoped<ITipo_TamanhoRepository, Tipo_TamanhoRepository>();



//Injeção de dependências para acesso aos serviços / regras de negócio
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

//builder.Services.AddDbContext<ApplicationDbContext>(
//    options =>
//    {
//        //options.UseMySql(builder.Configuration.GetConnectionString("DB_POSTGRESQL"));

//    }
//);

string mySqlConnection = builder.Configuration.GetConnectionString("DB_MySQL");

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
