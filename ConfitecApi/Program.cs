using AutoMapper;
using ConfitecApi.Configurations;
using ConfitecAplicacao.Usuarios.Interfaces;
using ConfitecAplicacao.Usuarios.Servicos;
using ConfitecCore.Usuarios.Interfaces.Repositorios;
using ConfitecInfrastructure.Data.Repositorio;
using ConfitecRepositorio.Data.Contexto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsuarioContexto>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Teste")));

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

var app = builder.Build();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseAuthorization();

app.MapControllers();

app.Run();
