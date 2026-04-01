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

var empleados = new List<Empleado> { new Empleado("Miguel", "Recursos Humanos", 1500m),
    new Comercial("Alberto", "Comercial", 1500m, 8),
    new Desarrollador("Maria", "Desarrollo", 1500m,5)
};

foreach (var empleado in empleados)
    Console.WriteLine($"{empleado.Nombre} - {empleado.Departamento}: {empleado.CalcularBonificacion():C}");

