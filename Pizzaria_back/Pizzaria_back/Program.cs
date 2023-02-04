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
// **** Injeção de dependência ****
//Services AddSingleton sempre que o controller for instanciado, meu objeto será instanciado até a finalização da aplicação para TODOS os usuários da aplicação
//Services AddScoped objeto instanciado até a finalização do método 
//Services AddAddTransient  toda vez que o controlador é instanciado, será gerado uma nova instância do objeto em dependencia
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
