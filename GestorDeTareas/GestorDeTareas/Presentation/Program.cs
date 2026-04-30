using static GestorDeTareas.Dominio.Enums.Enumerados;
using GestorDeTareas.Dominio.Entities;


var listaTareas = new List<TareaAction> {
               new TareaAction (1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), null, PrioridadTarea.Media, null, null, EstadoTarea.Pendiente,0,0),
               new TareaAction (2, "Tarea 2","Tarea nueva que a ver que pasa 2 lo serializa bien","Riki", DateTime.Today.AddDays(2), null, PrioridadTarea.Alta, null,null,EstadoTarea.EnProgreso,0,0),
               new TareaAction (3, "Tarea 3","Tarea nueva que a ver que pasa 3 cambio","Morty Smithz", DateTime.Today.AddDays(3), null, PrioridadTarea.Baja, null,null,EstadoTarea.Completada,0,0),
               new TareaAction (4, "Tarea 4","Tarea nueva que a ver que pasa 4 cambio","Morty Sanchez", DateTime.Today.AddDays(4), null, PrioridadTarea.Alta, null,null,EstadoTarea.Pendiente,0,0),
               new TareaAction (5, "Tarea 5","Tarea nueva que es la ultima de las que se añaden para crear el JSON de memoria de datos","Miguel Cervera", DateTime.Today.AddDays(5), null, PrioridadTarea.Baja, null, null,EstadoTarea.Completada,0,0)};

var builder = WebApplication.CreateBuilder(args);

// PARTE 1: registrar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// PARTE 2: configurar el pipeline de peticiones
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run(); // arranca el servidor y se queda escuchando