using GerenciadorImoveis.Dominio.Interfaces;
using GerenciadorImoveis.Dominio.Interfaces.Repositorios;
using GerenciadorImoveis.Dominio.Manipuladores;
using GerenciadorImoveis.Infraestrutura.Contexto;
using GerenciadorImoveis.Infraestrutura.EntradaSaida;
using GerenciadorImoveis.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GrenciadorImoveisAPI", Version = "v1" });
});

builder.Services.AddDbContext<ContextoBancoDeDados>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

//manipuladores
builder.Services.AddScoped<IManipularArquivo, ManipularArquivo>();
builder.Services.AddScoped<ClienteManipulador>();
builder.Services.AddScoped<ImovelManipulador>();

//repositorios
builder.Services.AddScoped<IArquivoRepositorio, ArquivoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IImovelRepositorio, ImovelRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
builder.Services.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();
builder.Services.AddScoped<IPlantaRepositorio, PlantaRepositorio>();
builder.Services.AddScoped<IEventoRepositorio, EventoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GrenciadorImoveisAPI");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
