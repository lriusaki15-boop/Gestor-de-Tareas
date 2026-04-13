using Gestor_de_Tareas;
using GestorDeTareas;
using static GestorDeTareas.Tarea;

var t1 = new List<Tarea> {new TareaAction(1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), DateTime.Today.AddDays(2),null, PrioridadTarea.Baja, EstadoTarea.Pendiente, null, null),
           new TareaAction(1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), DateTime.Today.AddDays(2),null, PrioridadTarea.Baja, EstadoTarea.Pendiente, null, null),
           new TareaAction(1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), DateTime.Today.AddDays(2),null, PrioridadTarea.Baja, EstadoTarea.Pendiente, null, null) };

foreach(var t2 in t1)
{
    Console.WriteLine(t2.Estado);
    if (t2.Iniciar())
    {
        Console.WriteLine(t2.Estado);
    }
}

//Ejemplo de como introducir datos por consola
Console.WriteLine("Introduzca un texto");
String texto;
texto = Console.ReadLine();
Console.WriteLine("El texto introducido es: " + texto);