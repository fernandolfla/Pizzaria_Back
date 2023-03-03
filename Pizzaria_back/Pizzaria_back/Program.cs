using Microsoft.AspNetCore.Rewrite;
using Microsoft.OpenApi.Models;
using Pizzaria_back.Extensions;
using Pizzaria_back.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizzaria API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AdicionarDependenciasPizzaria(builder.Configuration);


var app = builder.Build();

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var options = new RewriteOptions().AddIISUrlRewrite(app.Environment.ContentRootFileProvider, "UrlRewrite.xml");
app.UseRewriter(options);

app.UseHttpsRedirection(); 

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.MapControllers();

app.Run();
