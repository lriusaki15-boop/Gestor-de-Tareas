using Gestor_de_Tareas;
using GestorDeTareas;
using static GestorDeTareas.Tarea;


var t1 = new List<Tarea> {new TareaAction(1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), null, PrioridadTarea.Media, null,_subTareas: null, EstadoTarea.Pendiente),
           new TareaAction(2, "Tarea 2","Tarea nueva que a ver que pasa 2 lo serializa bien","Riki", DateTime.Today.AddDays(2), null, PrioridadTarea.Alta, null,_subTareas: null,EstadoTarea.EnProgreso),
           new TareaAction(3, "Tarea 3","Tarea nueva que a ver que pasa 3 cambio","Morty Smithz", DateTime.Today.AddDays(3), null, PrioridadTarea.Baja, null, _subTareas: null,EstadoTarea.Completada) };

TareasJson.GuardarDatosJson(t1);

var listaTareasJson = TareasJson.RecuperarDatos();

listaTareasJson.ForEach(Console.WriteLine);


//Ejemplo de como introducir datos por consola
Console.WriteLine("Introduzca un texto");
String texto;
texto = Console.ReadLine();
Console.WriteLine("El texto introducido es: " + texto);