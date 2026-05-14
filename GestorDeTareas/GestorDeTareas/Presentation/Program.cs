using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static GestorDeTareas.Dominio.Enums.Enumerados;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GestorTareasContext> (options => options.UseSqlServer(builder.Configuration.GetConnectionString("GestorTareas")));

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly
    .GetExecutingAssembly()
    .GetName().Name}.xml";
    var xmlPath = Path.Combine(
    AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// PARTE 1: registrar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// PARTE 2: configurar el pipeline de peticiones
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run(); // arranca el servidor y se queda escuchando