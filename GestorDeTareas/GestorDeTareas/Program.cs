using Gestor_de_Tareas;
using GestorDeTareas;
using static GestorDeTareas.Tarea;


var t1 = new List<Tarea> {new TareaAction(1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), PrioridadTarea.Media, EstadoTarea.Pendiente, null),
           new TareaAction(2, "Tarea 2","Tarea nueva que a ver que pasa 2","Riki", DateTime.Today.AddDays(2), PrioridadTarea.Alta, EstadoTarea.EnProgreso, null),
           new TareaAction(3, "Tarea 3","Tarea nueva que a ver que pasa 3 cambio","Morty Smithz", DateTime.Today.AddDays(3), PrioridadTarea.Baja, EstadoTarea.Completada, null) };

TareasJson.GuardarDatosJson(t1);

var listaTareasJson= TareasJson.RecuperarDatos();

listaTareasJson.ForEach(Console.WriteLine);


//Ejemplo de como introducir datos por consola
Console.WriteLine("Introduzca un texto");
String texto;
texto = Console.ReadLine();
Console.WriteLine("El texto introducido es: " + texto);