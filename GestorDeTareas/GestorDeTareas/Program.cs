using GestorDeTareas;
using GestorDeTareas.Clases_Tareas;
using GestorDeTareas.Tareas_Json;
using static GestorDeTareas.Clases_Tareas.Tarea;
using static System.Runtime.InteropServices.JavaScript.JSType;

//if (TareasJson.RecuperarDatos().Count == 0)
//{

var listaTareas = new List<TareaAction> {
               new TareaAction (1, "Tarea 1","Tarea nueva que a ver que pasa 1","Timon Pubis", DateTime.Today.AddDays(1), null, PrioridadTarea.Media, null, null, EstadoTarea.Pendiente,0,0),
               new TareaAction (2, "Tarea 2","Tarea nueva que a ver que pasa 2 lo serializa bien","Riki", DateTime.Today.AddDays(2), null, PrioridadTarea.Alta, null,null,EstadoTarea.EnProgreso,0,0),
               new TareaAction (3, "Tarea 3","Tarea nueva que a ver que pasa 3 cambio","Morty Smithz", DateTime.Today.AddDays(3), null, PrioridadTarea.Baja, null,null,EstadoTarea.Completada,0,0),
               new TareaAction (4, "Tarea 4","Tarea nueva que a ver que pasa 4 cambio","Morty Sanchez", DateTime.Today.AddDays(4), null, PrioridadTarea.Alta, null,null,EstadoTarea.Pendiente,0,0),
               new TareaAction (5, "Tarea 5","Tarea nueva que es la ultima de las que se añaden para crear el JSON de memoria de datos","Miguel Cervera", DateTime.Today.AddDays(5), null, PrioridadTarea.Baja, null, null,EstadoTarea.Completada,0,0)};

//TareasJson.GuardarDatosJson(t1);
//}

TareasJson.GuardarDatosJson(listaTareas);
var listaTareasJson = TareasJson.RecuperarDatos();


listaTareasJson.ForEach(Console.WriteLine);
//Menu por consola provisional hasta que creemos el FRONT

string opcion;
bool salir = false;

do
{
    Console.Clear();
    Console.WriteLine("--- MENÚ DE OPCIONES ---");
    Console.WriteLine("1. Ver Listado de Tareas");
    Console.WriteLine("2. Crear una tarea");
    Console.WriteLine("3. Cancelar una Tarea");
    Console.WriteLine("4. Salir");
    Console.Write("Seleccione una opción: ");

    opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            string opcionDatoLista,opcionInicioTarea;
            bool opcionTareaInicio = false;
            Console.WriteLine("Has seleccionado ver la lista de Tareas \n\n ----------LISTADO TAREAS----------");
            listaTareas.ForEach(lista => Console.WriteLine("\n*Id:" + lista.Id + "\n-Titulo:"+lista.Titulo+"\n -Descripcion:"+lista.Descripcion));
            Console.Write("\n\nPara ver en detalle una tarea escriba su Id:");
            opcionDatoLista = Console.ReadLine();
            try
            {
                var datosDeBusqueda = listaTareas.Where(tarea => tarea.Id == int.Parse(opcionDatoLista));

                Console.Clear();
                if (datosDeBusqueda.Count() == 0)
                {
                    Console.WriteLine("No existe ese ID tarea\nPulsa cualquier tecla para volver al menu inicial.....");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("--------Resumen Tarea--------");
                    foreach (var dato in datosDeBusqueda)
                    {
                        Console.WriteLine("*Id de tarea:" + dato.Id + "\n-Titulo de la tarea:" + dato.Titulo + "\n-Descripcion:" + dato.Descripcion +
                            "\n-Responsable de la tarea:" + dato.Responsable + "\n-Fecha de Creacion de la tarea:" + dato.FechaCreacion +
                            "\n-Fecha de finalizacion de la tarea:" + dato.FechaFinTarea + "\n-Prioridad de la tarea:" + dato.Prioridad +
                            "\n-Estado de la tarea:" + dato.Estado + "\n-Motivo de la Cancelacion:"+dato.ObtenerMotivoCancelacion()
                            +"\n------Fin de los datos de la tarea------");
                        if (dato.Estado == EstadoTarea.Pendiente)
                        {
                            Console.WriteLine("¿Quieres iniciar la tarea? S/N");
                            opcionTareaInicio = true;
                        }
                    }
                }
                if (opcionTareaInicio)
                {
                    opcionInicioTarea = Console.ReadLine();
                    foreach (var dato in listaTareas)
                    {
                        if (opcionInicioTarea.ToUpper().Equals("S"))
                        {
                            if (dato.Id == int.Parse(opcionDatoLista))
                            {
                                dato.Iniciar();
                                Console.WriteLine("Tarea Iniciada");
                                Thread.Sleep(3000);
                                Console.WriteLine("Volviendo al menu inicial....");
                                Thread.Sleep(3000);
                                break;
                            }
                        }
                        else if (opcionInicioTarea.ToUpper().Equals("N"))
                        {
                            Console.WriteLine("Pulsa cualquier tecla para volver al menu inicial.....");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Pulsa cualquier tecla para volver al menu inicial.....");
                    Console.ReadKey();
                    break;
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Dato introducido incorrecto volviendo al menu principal.....");
                Thread.Sleep(3000);
                break;
            }
            break;
        case "2":
            Console.WriteLine("Has seleccionado Crear una tarea Nueva");
            Console.ReadKey();
            break;
        case "3":
            Console.WriteLine("Has seleccionado Cancelar una Tarea");
            string opcionCancelarDatoLista, opcionCancelarTarea, motivoCancelacion;
            bool opcionTareaCancelar = false;
            Console.WriteLine("Has seleccionado ver la lista de Tareas \n\n ----------LISTADO TAREAS----------");
            listaTareas.ForEach(lista => Console.WriteLine("\n*Id:" + lista.Id + "\n-Titulo:" + lista.Titulo + "\n -Descripcion:" + lista.Descripcion));
            Console.Write("\n\nPara ver en detalle una tarea escriba su Id:");
            opcionCancelarDatoLista = Console.ReadLine();
            try
            {
                var datosDeBusqueda = listaTareas.Where(tarea => tarea.Id == int.Parse(opcionCancelarDatoLista));

                Console.Clear();
                if (datosDeBusqueda.Count() == 0)
                {
                    Console.WriteLine("No existe ese ID tarea\nPulsa cualquier tecla para volver al menu inicial.....");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("--------Resumen Tarea--------");
                    foreach (var dato in datosDeBusqueda)
                    {
                        Console.WriteLine("*Id de tarea:" + dato.Id + "\n-Titulo de la tarea:" + dato.Titulo + "\n-Descripcion:" + dato.Descripcion +
                            "\n-Responsable de la tarea:" + dato.Responsable + "\n-Fecha de Creacion de la tarea:" + dato.FechaCreacion +
                            "\n-Fecha de finalizacion de la tarea:" + dato.FechaFinTarea + "\n-Prioridad de la tarea:" + dato.Prioridad +
                            "\n-Estado de la tarea:" + dato.Estado + "\n-Motivo de la Cancelacion:" + dato.ObtenerMotivoCancelacion()
                            + "\n------Fin de los datos de la tarea------");
                        if (dato.Estado != EstadoTarea.Cancelada && dato.Estado != EstadoTarea.Completada)
                        {
                            Console.WriteLine("¿Quieres Cancelar la tarea? S/N");
                            opcionTareaCancelar = true;
                        }
                    }
                }
                if (opcionTareaCancelar)
                {
                    opcionCancelarTarea = Console.ReadLine();
                    Console.WriteLine("Escriba el motivo de la cancelacion de la tarea:");
                    motivoCancelacion = Console.ReadLine();
                    foreach (var dato in listaTareas)
                    {
                        if (opcionCancelarTarea.ToUpper().Equals("S"))
                        {
                            if (dato.Id == int.Parse(opcionCancelarDatoLista))
                            {
                                dato.Cancelar(motivoCancelacion);
                                Console.WriteLine("Tarea Cancelada");
                                Thread.Sleep(3000);
                                Console.WriteLine("Volviendo al menu inicial....");
                                Thread.Sleep(3000);
                                break;
                            }
                        }
                        else if (opcionCancelarTarea.ToUpper().Equals("N"))
                        {
                            Console.WriteLine("Volviendo al menu inicial....");
                            Thread.Sleep(3000);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Pulsa cualquier tecla para volver al menu inicial.....");
                    Console.ReadKey();
                    break;
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Dato introducido incorrecto volviendo al menu principal.....");
                Thread.Sleep(3000);
                break;
            }
            break;
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



