using Gestor_de_Tareas;
using static Gestor_de_Tareas.Tarea;

var tarea = new List<Tarea> { new TareaSimple(1, "Tarea de prueba para ver que pasa", DateTime.MaxValue, PrioridadTarea.Baja, "Esta es la descripcion de la tarea") };
foreach (var tareaPrueba in tarea)
    Console.WriteLine(tareaPrueba.ObtenerResumen());