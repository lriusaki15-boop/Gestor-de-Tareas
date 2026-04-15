using Gestor_de_Tareas;
using GestorDeTareas;
using static GestorDeTareas.Tarea;

if (TareasJson.RecuperarDatos().Count == 0)
{

    var t1 = new List<Tarea> {new TareaAction(1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), null, PrioridadTarea.Media, null,_subTareas: null, EstadoTarea.Pendiente),
               new TareaAction(2, "Tarea 2","Tarea nueva que a ver que pasa 2 lo serializa bien","Riki", DateTime.Today.AddDays(2), null, PrioridadTarea.Alta, null,_subTareas: null,EstadoTarea.EnProgreso),
               new TareaAction(3, "Tarea 3","Tarea nueva que a ver que pasa 3 cambio","Morty Smithz", DateTime.Today.AddDays(3), null, PrioridadTarea.Baja, null, _subTareas: null,EstadoTarea.Completada),
               new TareaAction(4, "Tarea 4","Tarea nueva que a ver que pasa 4 cambio","Morty Sanchez", DateTime.Today.AddDays(4), null, PrioridadTarea.Alta, null, _subTareas: null,EstadoTarea.Pendiente),
               new TareaAction(5, "Tarea 5","Tarea nueva que es la ultima de las que se añaden para crear el JSON de memoria de datos","Miguel Cervera", DateTime.Today.AddDays(5), null, PrioridadTarea.Baja, null, _subTareas: null,EstadoTarea.Completada)};

    TareasJson.GuardarDatosJson(t1);
}

var listaTareasJson = TareasJson.RecuperarDatos();

//listaTareasJson.ForEach(Console.WriteLine);
//Menu por consola provisional hasta que creemos el FRONT

string opcion;
bool salir = false;

do
{
    Console.Clear();
    Console.WriteLine("--- MENÚ DE OPCIONES ---");
    Console.WriteLine("1. Ver Listado de Tareas");
    Console.WriteLine("2. Crear una tarea");
    Console.WriteLine("3. Eliminar una Tarea");
    Console.WriteLine("4. Salir");
    Console.Write("Seleccione una opción: ");

    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.WriteLine("Has seleccionado ver la lista de Tareas");
            listaTareasJson.ForEach(datosLista => Console.WriteLine(datosLista));
            Console.ReadKey();
            break;
        case "2":
            Console.WriteLine("Has seleccionado Crear una tarea Nueva");
            Console.ReadKey();
            break;
        case "3":
            Console.WriteLine("Has seleccionado Eliminar una Tarea");
            break;
        case "4":
            salir = true;
            Console.WriteLine("Saliendo del Menu por Consola del Gestor de Tareas");
            break;
        default:
            Console.WriteLine("Opción no válida, intente de nuevo.");
            Console.ReadKey();
            break;
    }
} while (!salir);



