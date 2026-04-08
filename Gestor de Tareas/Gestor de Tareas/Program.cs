using Gestor_de_Tareas;
using static Gestor_de_Tareas.Tarea;

/*Ejercicio 1
 * try
{
    var tarea = new Tarea(
    titulo: "Implementar login",
    fechaLimite: DateTime.Today.AddDays(7),
    prioridad: PrioridadTarea.Alta,
    descripcion: "Formulario con validación de credenciales"
    );

    Console.WriteLine("Tarea creada:");
    Console.WriteLine(tarea);
    Console.WriteLine($"Días restantes: {tarea.DiasRestantes}");

    bool iniciada = tarea.Iniciar();
    Console.WriteLine($"Iniciada: {iniciada}");
    Console.WriteLine($"Estado: {tarea.Estado}");

    // Intentar iniciar de nuevo
    bool reintento = tarea.Iniciar(); // → false
    Console.WriteLine($"Reintento: {reintento}");

    tarea.Completar();
    Console.WriteLine($"Estado final: {tarea.Estado}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error de negocio: {ex.Message}");
}*/

/*Ejercicio 2
 * Empleado datosEmpleado = new Empleado("Miguel", "Desarrollo", 1500m);
EmpleadoPorHoras datosEmpleadoPorHoras = new EmpleadoPorHoras("Miguel", "Desarrollo", 1500m, 6, 100m);
Console.WriteLine(datosEmpleado.ObtenerSalario() + " " + datosEmpleadoPorHoras.ObtenerSalario());*/

/* Ejercico 3
var empleados = new List<Empleado> { new Empleado("Miguel", "Recursos Humanos", 1500m),
    new Comercial("Alberto", "Comercial", 1500m, 8),
    new Desarrollador("Maria", "Desarrollo", 1500m,5)
};

foreach (var empleado in empleados)
    Console.WriteLine($"{empleado.Nombre} - {empleado.Departamento}: {empleado.CalcularBonificacion():C}");
*/
/* Ejercicio 4
var archivos = new List<Generador_Reporte> { new ReportePDF("Programacion para Tontos"), new ReporteExcell("Excell para TONTOS") };

foreach (var archivo in archivos)
    Console.WriteLine($"PDF generado:{archivo.Generar(8)}---- Excell Generado:{archivo.Generar(5)}");
*/

/*Ejercicio 5
MotorNotificacion notificaciones = new MotorNotificacion();
var listaNotificaciones = new List<INotificable> { new NotificadorEmail("server.com"), new NotificadorSMS("546484684", "+34") };
notificaciones.EnviarATodos(listaNotificaciones, "Mensaje estandar", "Esto es un mensaj de tu fencomputadora");*/

HistorialDeNavegacion historia = new HistorialDeNavegacion();
historia.Navegar("Estoy en la parte de atras");
Console.WriteLine($"Esto es adelante: {historia.Adelante()}\nEsto es para atras: {historia.Atras()}");
historia.Navegar("Estoy en la parte de alant");
Console.WriteLine($"Esto es adelante: {historia.Adelante()}\nEsto es para atras: {historia.Atras()}");
historia.Navegar("Estoy en la parte de atrasante");
Console.WriteLine($"Esto es adelante: {historia.Adelante()}\nEsto es para atras: {historia.Atras()}");
historia.Navegar("Estoy en la parte de alante");
Console.WriteLine($"Esto es para atras: {historia.Atras()} \nEsto es adelante: {historia.Adelante()}");

