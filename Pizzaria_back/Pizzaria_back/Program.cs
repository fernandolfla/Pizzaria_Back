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
// **** Inje��o de depend�ncia ****
//Services AddSingleton sempre que o controller for instanciado, meu objeto ser� instanciado at� a finaliza��o da aplica��o para TODOS os usu�rios da aplica��o
//Services AddScoped objeto instanciado at� a finaliza��o do m�todo 
//Services AddAddTransient  toda vez que o controlador � instanciado, ser� gerado uma nova inst�ncia do objeto em dependencia
*/
//Inje��o de dependencias para acesso ao reposit�rio
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITipoRepository, TipoRepository>();
builder.Services.AddScoped<ITamanhoRepository, TamanhoRepository>();
builder.Services.AddScoped<ISaborRepository, SaborRepository>();
builder.Services.AddScoped<ITipo_TamanhoRepository, Tipo_TamanhoRepository>();



//Inje��o de depend�ncias para acesso aos servi�os / regras de neg�cio
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
