using Pizzaria_back.Interfaces.Repository;
using Pizzaria_back.Interfaces.Service;
using Pizzaria_back.Repository;
using Pizzaria_back.Service;

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

builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();       
builder.Services.AddScoped<IProdutoService, ProdutoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
